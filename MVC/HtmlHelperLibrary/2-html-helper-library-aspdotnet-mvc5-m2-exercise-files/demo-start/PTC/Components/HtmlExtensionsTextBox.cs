using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace PTC
{
    public static class HtmlExtensionsTextBox
    {
        public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes = null
        ) {
            RouteValueDictionary rvd;

            rvd = new RouteValueDictionary(
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return InputExtensions.TextBoxFor(htmlHelper, expression, rvd);
        }
            
    }
}