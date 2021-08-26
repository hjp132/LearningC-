using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


[assembly: PreApplicationStartMethod(typeof(Modules.RegisterHelper), "Register")]

namespace Modules
{
    public class RegisterHelper
    {
        public static void Register()
        {
            HttpApplication.RegisterModule(typeof(LogModule));
        }

    }
}
