using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandleErrorAttributeFilters.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()//1 request
        {
            //  ViewData["Student"] = "Himani";
            // ViewBag.Student = "Himani";
            TempData["Student"] = "Himani";
            return RedirectToAction("About");
        }

        public ActionResult About()//2nd request
        {

            // string stName = Convert.ToString(ViewData["Student"]);
            //string stName = ViewBag.Student;
            // string StName = Convert.ToString(TempData["Student"]);
            //TempData.Keep();//Keep method mark All Tempdata keys  as retaintion of data

            string StName = Convert.ToString(TempData.Peek("Student"));


            ViewBag.Message = StName;

            return View();
        }
        //[HandleError(View="Error1")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            try
            {
                throw new Exception("FormatException", new FormatException());
                
            }
            catch (Exception ex)
            {
                if (ex.Message == "FormatException")
                    return View("Error",new HandleErrorInfo(ex,"Home","ContactUS"));
                else
                    return View("Error1", new HandleErrorInfo(ex, "Home", "ContactUS"));


            }


        }


    }
}