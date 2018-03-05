using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace more.custom
{
    public static class customhelper
    {
        public static IHtmlString img(this HtmlHelper helper, string src,string alt)
        {
            TagBuilder tg = new TagBuilder("img");
            tg.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tg.Attributes.Add("alt", alt);
            return new MvcHtmlString(tg.ToString(TagRenderMode.SelfClosing));
        } 
    }
}