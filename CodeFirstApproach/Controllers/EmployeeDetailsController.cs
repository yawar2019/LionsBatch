using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        // GET: EmployeeDetails

        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.EmployeeModels.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            db.EmployeeModels.Add(employee);//insert query
           int i= db.SaveChanges();

            if(i>0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
           var employeeModel= db.EmployeeModels.Find(id);

            return View(employeeModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;//update query

            int i = db.SaveChanges();

            if (i > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            var employeeModel = db.EmployeeModels.Find(id);

            return View(employeeModel);
        }

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int? id)
        {
            var employeeModel = db.EmployeeModels.Find(id);

            db.EmployeeModels.Remove(employeeModel);



            int i = db.SaveChanges();

            if (i > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}

//Commands for Code first Approach Migration

//Enable-Migrations
//Add-Migration Creating_Designation_column
//update-database