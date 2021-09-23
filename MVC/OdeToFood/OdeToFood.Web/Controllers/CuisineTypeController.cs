using OdeToFood.Data.Services;
using OdeToFood.Data.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using OdeToFood.Web.Models;
using OdeToFood.Web.Common;

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
            var cuisine = db.Get(id);
            if (cuisine == null)
            {
                return View("NotFound");
            }

            var model = new CuisineTypeViewModel()
            {
                Name = cuisine.Name
            };
            model.ImageFileToDisplay = cuisine.ImageFile;
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CuisineTypeViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuisineTypeViewModel cuisine, HttpPostedFileBase image)
        {
            string FileName = HelperClass.GetFileName(image);
            var bytes = HelperClass.PostedImageToByte(image);

            var model = new Data.Models.CuisineType()
            {
                Name = cuisine.Name,
                ImageFile = bytes,
                ImagePath = FileName,
            };
            
            if (ModelState.IsValid)
            {
                db.Add(model);
                return RedirectToAction("Index", new { id = model.Id });
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cuisine = db.Get(id);
            if (cuisine == null)
            {
                return View("NotFound");
            }

            var model = new CuisineTypeViewModel()
            {
                Name = cuisine.Name
            };
            model.ImageFileToDisplay = cuisine.ImageFile;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HttpPostedFileBase image)
        {
            var cuisine = db.Get(id);

            string FileName = HelperClass.GetFileName(image);
            var bytes = HelperClass.PostedImageToByte(image);

            cuisine.ImageFile = bytes;


            var model = new CuisineTypeViewModel()
            {
                Id = cuisine.Id,
                Name = cuisine.Name,
                ImageFileToDisplay = cuisine.ImageFile
            };

            if (ModelState.IsValid)
            {
                db.Update(cuisine);
                TempData["Message"] = "You have saved the CuisineType!";
                return RedirectToAction("Details", new { id = cuisine.Id });
            }
            return View(cuisine);
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

