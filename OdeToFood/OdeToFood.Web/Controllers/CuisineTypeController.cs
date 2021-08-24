using OdeToFood.Data.Services;
using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class CuisineTypeController : Controller
    {

        private readonly ICuisineTypeData db;

        public CuisineTypeController(ICuisineTypeData db)
        {
            this.db = db;
        }
        // GET: FoodType
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuisineType cuisineType)
        {
            if (String.IsNullOrEmpty(cuisineType.Name))
            {
                ModelState.AddModelError(nameof(cuisineType.Name), "The name is required");
            }

            if (ModelState.IsValid)
            {
                db.Add(cuisineType);
                return RedirectToAction("Details", new { id = cuisineType.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CuisineType cuisineType)
        {
            if (ModelState.IsValid)
            {
                db.Update(cuisineType);
                TempData["Message"] = "You have saved the CuisineType!";
                return RedirectToAction("Details", new { id = cuisineType.Id });
            }
            return View(cuisineType);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
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