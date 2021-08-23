using OdeToFood.Data.Services;
using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class FoodTypeController : Controller
    {

        private readonly IRestaurantData db;

        public FoodTypeController(IRestaurantData db)
        {
            this.db = db;
        }
        // GET: FoodType
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View();
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
    }
}