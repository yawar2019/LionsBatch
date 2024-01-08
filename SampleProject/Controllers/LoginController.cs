using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SampleProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult AboutUS()
        {
            return View();
        }
        [Authorize(Roles="Manager")]
        public ActionResult ContactUS()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName,string Password)
        {
            if (UserName == "Amair" && Password == "Amair")
            {
                FormsAuthentication.SetAuthCookie(UserName, false);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();

            }
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}