using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

            return "Deepak " + result;
        }

        public string GetId(int? eid)
        {
            return "My Employee Id is " + eid;

        }

        public string GetEmpDetails(int? eid)//http:localhost:1209//HomeGetEmpDetails?EmpName=radha&DesigNation=Developer
        {
            return "My Employee Id is " + eid + " EmpName is " + Request.QueryString["EmpName"] + " DesigNation " + Request.QueryString["DesigNation"];
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

        public ActionResult SendMultipleEmpDetailToView()
        {
            EmployeeModel employee1 = new EmployeeModel();
            employee1.EmpName = "Hari";
            employee1.Id = 1211;
            employee1.EmpSalary = 900000;

            EmployeeModel employee2 = new EmployeeModel();
            employee2.EmpName = "pari";
            employee2.Id = 1212;
            employee2.EmpSalary = 800000;

            EmployeeModel employee3 = new EmployeeModel();
            employee3.EmpName = "Dhari";
            employee3.Id = 1213;
            employee3.EmpSalary = 700000;





            List<EmployeeModel> listemp = new List<EmployeeModel>();
            listemp.Add(employee1);
            listemp.Add(employee2);
            listemp.Add(employee3);

            ViewBag.listEmp = listemp;

            return View();
        }


        public ActionResult SendEmpDetailToViewByModel()
        {
            EmployeeModel employee = new EmployeeModel();
            employee.EmpName = "Hari";
            employee.Id = 1211;
            employee.EmpSalary = 900000;


            //object model=employee;
            return View(employee);
        }

        public ActionResult SendMultipleEmpDetailToViewModel()
        {
            EmployeeModel employee1 = new EmployeeModel();
            employee1.EmpName = "Hari";
            employee1.Id = 1211;
            employee1.EmpSalary = 900000;

            EmployeeModel employee2 = new EmployeeModel();
            employee2.EmpName = "pari";
            employee2.Id = 1212;
            employee2.EmpSalary = 800000;

            EmployeeModel employee3 = new EmployeeModel();
            employee3.EmpName = "Dhari";
            employee3.Id = 1213;
            employee3.EmpSalary = 700000;





            List<EmployeeModel> listemp = new List<EmployeeModel>();
            listemp.Add(employee1);
            listemp.Add(employee2);
            listemp.Add(employee3);


            return View(listemp);
        }


        public ViewResult GetEmpDeptDetails(EmployeeModel emp) //string eid,string ename
        {
            EmployeeModel employee1 = new EmployeeModel();
            employee1.EmpName = "Hari";
            employee1.Id = 1211;
            employee1.EmpSalary = 900000;

            EmployeeModel employee2 = new EmployeeModel();
            employee2.EmpName = "pari";
            employee2.Id = 1212;
            employee2.EmpSalary = 800000;

            EmployeeModel employee3 = new EmployeeModel();
            employee3.EmpName = "Dhari";
            employee3.Id = 1213;
            employee3.EmpSalary = 700000;





            List<EmployeeModel> listemp = new List<EmployeeModel>();
            listemp.Add(employee1);
            listemp.Add(employee2);
            listemp.Add(employee3);

/////department details
            DeptModel dept1 = new DeptModel();
            dept1.Did = 81;
            dept1.Dname = "Java";

            DeptModel dept2 = new DeptModel();
            dept2.Did = 82;
            dept2.Dname = "Python";


            List<DeptModel> listdept = new List<DeptModel>();
            listdept.Add(dept1);
            listdept.Add(dept2);

            EmpDept empdept = new EmpDept();
            empdept.emp = listemp;
            empdept.dept = listdept;


            return View(empdept);
        }

        public RedirectResult GotoSomeLocation()//redirect to specific url
        {
          //  return Redirect("http://www.google.com");
           return Redirect("http://localhost:64809/Home/GetEmpDeptDetails?id=1211&name=Deepika");
        }
         
        public RedirectToRouteResult gotoOtherLocation()
        {

            return RedirectToAction("GetEmpDeptDetails", "Home", new {eid=1211,ename="Piyush"});
        }
        public RedirectToRouteResult gotoOtherLocation2()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.Id = 11;
            emp.EmpName = "HelloWorld";
            emp.EmpSalary = 1120;

            return RedirectToAction("GetEmpDeptDetails", "Home", emp);
        }

        public RedirectToRouteResult gotoOtherLocation3()
        {

            return RedirectToRoute("MyAboutUsPage");
        }

        public  PartialViewResult getMePartialView()
        {
            EmployeeModel _reactBatch = new EmployeeModel();
            _reactBatch.EmpName = "Umair";


            EmployeeModel _reactBatch1 = new EmployeeModel();
            _reactBatch1.EmpName = "Prasad";

            List<EmployeeModel> listemp = new List<EmployeeModel>();
            listemp.Add(_reactBatch);
            listemp.Add(_reactBatch1);
            return PartialView("_ReactStudentsView", listemp);
        }
    }
}

//employee detail and Department detail using same ViewModel

//Viewresult-which is used to render view page and pass data to view as model
//RedirectResult- redirect from one page to another it just ask for url
//RedirectToRouteResult-RedirectToAction which ask for action method ,controller and parameters
                        //Just use for junping from one action method another method