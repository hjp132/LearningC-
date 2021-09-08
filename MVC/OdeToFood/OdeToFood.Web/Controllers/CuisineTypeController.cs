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
            var model = new CuisineTypeViewModel();
            


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuisineType cuisineType, HttpPostedFileBase postedFile)
        {
            var model = new CuisineTypeViewModel();

            if (String.IsNullOrEmpty(cuisineType.Name))
            {
                ModelState.AddModelError(nameof(cuisineType.Name), "The name is required");
            }

            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                cuisineType.ImageFile = br.ReadBytes(postedFile.ContentLength);
                
                
                
            }



            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Does work");
                db.Add(cuisineType);
                return RedirectToAction("Details", new { id = cuisineType.Id });
            }

            System.Diagnostics.Debug.WriteLine("Doesn't work");
            return View();
        }


        //public ActionResult Create(CuisineType cuisineType)
        //{
        //    if (String.IsNullOrEmpty(cuisineType.Name))
        //    {
        //        ModelState.AddModelError(nameof(cuisineType.Name), "The name is required");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Does work");


        //        //Use Namespace called :  System.IO  
        //        string FileName = Path.GetFileNameWithoutExtension(cuisineType.ImageFile.FileName);

        //        //To Get File Extension  
        //        string FileExtension = Path.GetExtension(cuisineType.ImageFile.FileName);

        //        //Add Current Date To Attached File Name  
        //        FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

        //        //Get Upload path from Web.Config file AppSettings.  
        //        string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

        //        //Its Create complete path to store in server.  
        //        cuisineType.ImagePath = UploadPath + FileName;

        //        //To copy and save file into server.  
        //        cuisineType.ImageFile.SaveAs(cuisineType.ImagePath);

        //        db.Add(cuisineType);
        //        return RedirectToAction("Details", new { id = cuisineType.Id });
        //    }





        //    System.Diagnostics.Debug.WriteLine("Doesn't work");
        //    return View();
        //}

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
                ////Use Namespace called :  System.IO  
                //string FileName = Path.GetFileNameWithoutExtension(cuisineType.ImageFile.FileName);

                ////To Get File Extension  
                //string FileExtension = Path.GetExtension(cuisineType.ImageFile.FileName);

                ////Add Current Date To Attached File Name  
                //FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                ////Get Upload path from Web.Config file AppSettings.  
                //string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                ////Its Create complete path to store in server.  
                //cuisineType.ImagePath = UploadPath + FileName;

                ////To copy and save file into server.  
                //cuisineType.ImageFile.SaveAs(cuisineType.ImagePath);

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