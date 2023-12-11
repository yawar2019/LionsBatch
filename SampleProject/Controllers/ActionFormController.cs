using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class ActionFormController : Controller
    {
        // GET: ActionForm
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetInfo(string EmpName)
        {
            ViewBag.EmpName = "Mr. "+EmpName;
            return View("Index");
        }
    }
}