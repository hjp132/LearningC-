using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        private ICuisineTypeData cuisineTypeData;

        public RestaurantsController(IRestaurantData db, ICuisineTypeData cuisineTypeData)
        {
            this.db = db;
            this.cuisineTypeData = cuisineTypeData;
        }

   


        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var restaurant = db.Get(id);

            if(restaurant == null)
            {
                return View("NotFound");
            }

            var model = new RestaurantViewModel() { cuisineTypeID = restaurant.cuisineTypeID, Id = restaurant.Id, Name = restaurant.Name };
            model.CuisineTypesList = cuisineTypeData.GetAll()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();

          
            return View(model);
        }
  
        [HttpGet]
        public ActionResult Create()
        {
            var model = new RestaurantViewModel();
            model.CuisineTypesList = cuisineTypeData.GetAll()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                //.Select(x => new SelectListItem { Text = $"{x}", Value = $"{x}" })
                .ToList();
                
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (String.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            }

            if (ModelState.IsValid)
            {
            db.Add(restaurant);
            return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var restaurant = db.Get(id);
            
            if (restaurant == null)
            {
                return View("NotFound");
            }

            var model = new RestaurantViewModel() { cuisineTypeID = restaurant.cuisineTypeID, Id = restaurant.Id, Name = restaurant.Name };
            model.CuisineTypesList = cuisineTypeData.GetAll()
            .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            .ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Update(restaurant);
                TempData["Message"] = "You have saved the restaurant!";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}