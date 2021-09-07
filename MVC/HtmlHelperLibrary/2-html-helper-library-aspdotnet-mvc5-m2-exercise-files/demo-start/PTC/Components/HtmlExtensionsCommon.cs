using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace PTC
{
    public class HtmlExtensionsCommon
    {

        public enum HtmlButtonTypes
        {
            submit,
            button,
            reset
        }
        public static void AddName(TagBuilder tb,
            string name, string id)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {

                if (string.IsNullOrWhiteSpace(id)){
                    tb.GenerateId(name);
                }
                else
                {
                    tb.MergeAttribute("id", TagBuilder.CreateSanitizedId(id));
                }      
            }
            tb.MergeAttribute("name", name);
        }
    }
}