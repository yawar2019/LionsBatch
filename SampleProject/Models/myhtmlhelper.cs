using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Models
{

    //by using static method we can create user defined control
    public static class myhtmlhelper
    {
        public static IHtmlString MyLabel(string content)
        {
            string htmlstring = String.Format("<label>{0}</label>", content);
            return new HtmlString(htmlstring);
        }

        public static IHtmlString createUrControl(this HtmlHelper helper, string type)
        {
            string htmlstring = "<input type=" + type + ">";
            return new HtmlString(htmlstring);
        }

        public static IHtmlString createUrControl(this HtmlHelper helper, string type, string functionname)
        {
            string htmlstring = "<input type=" + type + " onclick=" + functionname + ">";
            return new HtmlString(htmlstring);
        }

    }
}