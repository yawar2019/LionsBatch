using SampleProject.Models;
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
        StudentModel st = new StudentModel();
        public ActionResult ShowStudentDetails()
        {
            
            var stdet = st.ShowStudentData();
            return View(stdet);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentDataModel stud)
        {
            var result = st.SaveStudentData(stud);
            if(result>0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Edit(int? id)
        {
           StudentDataModel studentData= st.GetStudentDetail(id);
            return View(studentData);
        }

        [HttpPost]
        public ActionResult Edit(StudentDataModel stud)
        {
            var result = st.EditStudentData(stud);
            if (result > 0)
            {
                return RedirectToAction("ShowStudentDetails");
            }

            return View();
        }


        public ActionResult Delete(int? id)
        {
            StudentDataModel studentData = st.GetStudentDetail(id);
            return View(studentData);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            var result = st.DeleteStudentData(id);
            if (result > 0)
            {
                return RedirectToAction("ShowStudentDetails");
            }

            return View();
        }

    }
}