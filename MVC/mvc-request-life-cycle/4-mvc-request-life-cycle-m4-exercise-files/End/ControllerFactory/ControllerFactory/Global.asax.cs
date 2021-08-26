using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ControllerFactory
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PreRequestHandlerExecute()
        {
            Debug.WriteLine("PreExecute");
        }

        protected void Application_PostRequestHandlerExecute()
        {
            Debug.WriteLine("PostExecute");
        }

        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(new ParameterControllerFactory());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
