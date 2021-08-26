using SelectorTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelectorTest.Controllers
{
    public class HomeController : Controller
    {
        [IsMobile]
        public JsonResult Register()
        {
            return Json("{ Message: Display on Mobile Devices }");
        }         

        public ActionResult Register(string name)
        {
            return View();
        }

    }
}