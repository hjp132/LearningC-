using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HealthModules
{
    public class LogModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.LogRequest += LogEvent;
        }

        private void LogEvent(object src, EventArgs args)
        {
            if (HttpContext.Current.CurrentNotification == RequestNotification.LogRequest)
            {
                if ((MvcHandler)HttpContext.Current.Handler != null)
                {
                    Debug.WriteLine("This was logged!");
                }

            }
        }
    }
}
