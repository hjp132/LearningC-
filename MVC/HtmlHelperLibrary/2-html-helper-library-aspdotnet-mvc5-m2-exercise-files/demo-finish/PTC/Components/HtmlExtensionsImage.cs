using System;
using System.Text;
using System.Web.Mvc;

namespace PTC
{
  public static class HtmlExtensionsImage
  {
    /// <summary>
    /// Bootstrap Image Helper
    /// </summary>
    /// <param name="htmlHelper">The helper</param>
    /// <param name="src">The source of the picture to display</param>
    /// <param name="altText">The alternate text to display</param>
    /// <param name="htmlAttributes">An object that sets the HTML attributes for the element (optional)</param>
    /// <returns>A HTML &lt;img&gt; element with the appropriate properties set</returns>
    public static MvcHtmlString Image(
      this HtmlHelper htmlHelper,
      string src,
      string altText,
      object htmlAttributes = null) {

      return HtmlExtensionsImage.Image(htmlHelper, src, altText,
          string.Empty, string.Empty, htmlAttributes);

    }

    /// <summary>
    /// Bootstrap Image Helper
    /// </summary>
    /// <param name="htmlHelper">The helper</param>
    /// <param name="src">The source of the picture to display</param>
    /// <param name="altText">The alternate text to display</param>
    /// <param name="cssClass">Any CSS classes to add to the image</param>
    /// <param name="htmlAttributes">An object that sets the HTML attributes for the element (optional)</param>
    /// <returns>A HTML &lt;img&gt; element with the appropriate properties set</returns>
    public static MvcHtmlString Image(
      this HtmlHelper htmlHelper,
      string src,
      string altText,
      string cssClass,
      object htmlAttributes = null) {

      return HtmlExtensionsImage.Image(htmlHelper, src, altText,
          cssClass, string.Empty, htmlAttributes);

    }

    /// <summary>
    /// Bootstrap Image Helper
    /// </summary>
    /// <param name="htmlHelper">The helper</param>
    /// <param name="src">The source of the picture to display</param>
    /// <param name="altText">The alternate text to display</param>
    /// <param name="cssClass">Any CSS classes to add to the image</param>
    /// <param name="name">The name of this element</param>
    /// <param name="htmlAttributes">An object that sets the HTML attributes for the element (optional)</param>
    /// <returns>A HTML &lt;img&gt; element with the appropriate properties set</returns>
    public static MvcHtmlString Image(
      this HtmlHelper htmlHelper,
      string src,
      string altText,
      string cssClass,
      string name,
      object htmlAttributes = null) {
      TagBuilder tb = new TagBuilder("img");

      // Add 'name' and 'id' attributes if present
      if (!string.IsNullOrWhiteSpace(name)) {
        // Ensure we have valid name
        name = TagBuilder.CreateSanitizedId(name);

        // Generate a valid 'id' attribute 
        // from the 'name' attribute
        tb.GenerateId(name);

        // Add 'name' to HTML
        tb.MergeAttribute("name", name);
      }

      if (!string.IsNullOrWhiteSpace(cssClass)) {
        tb.AddCssClass(cssClass);
      }
      tb.MergeAttribute("src", src);
      tb.MergeAttribute("alt", altText);

      // Add additional attributes
      tb.MergeAttributes(
       HtmlHelper.AnonymousObjectToHtmlAttributes(
       htmlAttributes));

      return MvcHtmlString.Create(tb.ToString(
                 TagRenderMode.SelfClosing));
    }
  }
}