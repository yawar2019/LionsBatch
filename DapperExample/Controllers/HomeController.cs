using Dapper;
using DapperExample.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperExample.Controllers
{
    public class HomeController : Controller
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-L1958T5\\SQLSERVER;Initial Catalog=HarshaDb;Integrated Security=true");

        // GET: Home
        public ActionResult Index()
        {
            //var result = con.Query<EmployeeModel>("SELECT * from EmployeeModels");
            var result = con.Query<EmployeeModel>("sp_getEmployee", commandType: System.Data.CommandType.StoredProcedure);
            ViewBag.Employees = new SelectList(result, "EmpId", "EmpName");

            return View(result);
        }

        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmpName", emp.EmpName);
            parameters.Add("@EmpSalary", emp.EmpSalary);

            int i = con.Execute("sp_saveEmployee", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (i > 0)
            {
                return RedirectToAction("Index");

            }
            return View();

        }

        public ActionResult StronglyTypeHtmlHelper()
        {
            var result = con.Query<EmployeeModel>("sp_getEmployee", commandType: System.Data.CommandType.StoredProcedure);
            ViewBag.Employees = new SelectList(result, "EmpId", "EmpName");
            return View();

        }
        [HttpPost]
        public ActionResult StronglyTypeHtmlHelper(RegistrationModel registration)
        {
            var result = con.Query<EmployeeModel>("sp_getEmployee", commandType: System.Data.CommandType.StoredProcedure);
            ViewBag.Employees = new SelectList(result, "EmpId", "EmpName");
            return View();

        }


        public ActionResult StronglyTypeEditorFor()
        {
            return View();

        }


        public ActionResult ShowData()
        {
            var result = con.Query<EmployeeModel>("sp_getEmployee", commandType: System.Data.CommandType.StoredProcedure);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public  ActionResult AjaxCallMethod()
        {
            return View();
        }

        public ActionResult ValidationExample()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ValidationExample(RegistrationModel registration)
        {
            if(!ModelState.IsValid)
            {
                return View(registration);
            }
            else
            {
                return View();

            }
        }
    }
}