﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAssist.Handlers
{
    public class SampleHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<p>This was geneterated by the sample handler</p>");
        }
    }
}