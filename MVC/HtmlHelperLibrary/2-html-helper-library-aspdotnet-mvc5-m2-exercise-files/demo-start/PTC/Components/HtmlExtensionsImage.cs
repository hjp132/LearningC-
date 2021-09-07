using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Net;

namespace PTC
{
    public static class HtmlExtensionsImage
    {
        public static MvcHtmlString Image(this HtmlHelper htmlHelper,
            string src, string altText, string cssClass,
            object htmlAttributes = null)
        {
            return HtmlExtensionsImage.Image(htmlHelper, src, altText,
                string.Empty, string.Empty, htmlAttributes);
        }


        public static MvcHtmlString Image(this HtmlHelper htmlHelper, 
            string src, string altText, string cssClass, string name,
            object htmlAttributes = null)
        {
            TagBuilder tb = new TagBuilder("img");

            tb.MergeAttribute("src", src);
            tb.MergeAttribute("alt", altText);

            HtmlExtensionsCommon.AddName(tb, name, "");


            tb.MergeAttributes(
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

                if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tb.AddCssClass(cssClass);
            }
         

            // HTML Encode String
            return MvcHtmlString.Create(tb.ToString(
                TagRenderMode.SelfClosing));
        }
    }
}