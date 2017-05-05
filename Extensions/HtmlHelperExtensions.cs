namespace KNGSoftware.Extensions
{
    using System.Web.Mvc;

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper html, string imageURL, string alt)
        {
            TagBuilder imageBuilder = new TagBuilder("img");
            imageBuilder.MergeAttribute("src", imageURL);
            imageBuilder.MergeAttribute("alt", alt);
            string imageString = imageBuilder.ToString(TagRenderMode.SelfClosing);

            TagBuilder actionBuilder = new TagBuilder("a");
            actionBuilder.AddCssClass("navbar-brand");
            actionBuilder.MergeAttribute("href", "/");
            actionBuilder.InnerHtml = imageString;

            return new MvcHtmlString(actionBuilder.ToString(TagRenderMode.Normal));
        }
    }
}