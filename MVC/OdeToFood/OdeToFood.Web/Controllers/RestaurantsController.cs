using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using OdeToFood.Web.Common;
using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        private readonly ICuisineTypeData cuisineTypeData;
        private readonly IRestaurantImagesData restaurantImagesData;

        public RestaurantsController(IRestaurantData db, ICuisineTypeData cuisineTypeData, IRestaurantImagesData restaurantImagesData)
        {
            this.db = db;
            this.cuisineTypeData = cuisineTypeData;
            this.restaurantImagesData = restaurantImagesData;
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

            var model = new RestaurantViewModel() { cuisineTypeID = restaurant.cuisineTypeID, Id = restaurant.Id, Name = restaurant.Name, Desc = restaurant.Desc};
            model.CuisineTypesList = cuisineTypeData.GetAll()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString()})
                .ToList();

            model.CuisineText = cuisineTypeData.GetAll()
                .FirstOrDefault(x => x.Id == restaurant.cuisineTypeID)?.Name;
             
            model.RestaurantImages = restaurantImagesData.GetByRestaurantID(id)
                .Select(x => new RestaurantImagesViewModel { ImageFile = x.ImageFile, RestaurantId = x.RestaurantId, ImagePath = x.ImagePath, Id = x.Id })
                .ToList();


            return View(model);
        }
  
        [HttpGet]
        public ActionResult Create()
        {
            var model = new RestaurantViewModel();

            var cusineTypes = cuisineTypeData.GetAll();
            model.CuisineTypesList = cusineTypes.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {

            //if (String.IsNullOrEmpty(restaurant.Name))
            //{

            //    ModelState.AddModelError(nameof(restaurant.Name), "The field is required");
            //}

            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return RedirectToAction("Create");
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var restaurant = db.Get(id);
            
            // TODO - if null redirect to notfound should be added to common
            if (restaurant == null)
            {
                return View("NotFound");
            }

            var model = new RestaurantViewModel() { cuisineTypeID = restaurant.cuisineTypeID, Id = restaurant.Id, Name = restaurant.Name, Desc = restaurant.Desc};
            model.CuisineTypesList = cuisineTypeData.GetAll()
            .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            .ToList();

            model.RestaurantImages = restaurantImagesData.GetByRestaurantID(id)
                .Select(x => new RestaurantImagesViewModel { ImageFile = x.ImageFile, RestaurantId = x.RestaurantId, ImagePath = x.ImagePath, Id = x.Id })
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

        [HttpGet]
        public ActionResult AddImage(int id)
        {

            var restaurantImages = restaurantImagesData.Get(id);
            if (restaurantImages == null)
            {
                return View("NotFound");
            }
            var model = new RestaurantImagesViewModel();
            model.ImageFile = restaurantImages.ImageFile;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage(int id, HttpPostedFileBase image)
        {
            string FileName = HelperClass.GetFileName(image);
            var bytes = HelperClass.PostedImageToByte(image);

            if (ModelState.IsValid)
            {
                var restaurantImage = new RestaurantImages()
                {
                    RestaurantId = id,
                    ImageFile = bytes,
                    ImagePath = FileName
                };
                restaurantImagesData.Add(restaurantImage);
            }

            return RedirectToAction("Edit", new { id = id });


        }


        public ActionResult DeleteImage(int restaurantImageId, int restaurantId)
        {
            restaurantImagesData.Delete(restaurantImageId);
            return RedirectToAction("Edit", new { id = restaurantId });

        }
    }
}