using CustomActionResult.Extensions;
using CustomActionResult.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomActionResult.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var person = new Person { FirstName = "Bob", LastName = "John", Age = 32 };
            return JsonNet(person);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private ActionResult JsonNet(object data)
        {
            return new JsonNETResult() { Data = data };
        }
    }
}