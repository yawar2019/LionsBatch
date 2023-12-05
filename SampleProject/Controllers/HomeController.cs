using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public int Index()
        {
            int a = 10, b = 20;
            int c = a + b;
            return c;
        }
        public string GetName()
        {
            int result = Index();

            return "Deepak "+result;
        }

        public string GetId(int? eid)
        {
            return "My Employee Id is "+ eid;
        
        }

        public string GetEmpDetails(int? eid)//http:localhost:1209//HomeGetEmpDetails?EmpName=radha&DesigNation=Developer
        {
            return "My Employee Id is " + eid+" EmpName is " + Request.QueryString["EmpName"]+" DesigNation " + Request.QueryString["DesigNation"];
        }

        public ActionResult GetView()
        {
            return View("Index");
        }

        public ActionResult GetViewOtherFolder()
        {
            return View("~/Views/AboutUS/Index.cshtml");
        }

        public ActionResult SendNameToView()
        {
            
            ViewBag.EmpName = "Deepika";

            return View();
        }

        public ActionResult SendEmpDetailToView()
        {
            EmployeeModel employee = new EmployeeModel();
            employee.EmpName = "Hari";
            employee.Id = 1211;
            employee.EmpSalary = 900000;

            ViewBag.Emp = employee;

            return View();
        }

    }
}