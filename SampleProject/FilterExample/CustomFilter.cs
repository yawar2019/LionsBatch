using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.FilterExample
{
    public class CustomFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            (filterContext.Result as ViewResult).ViewBag.PlayerName = "Virat Kohli";
            EmployeeModel model=(EmployeeModel)(filterContext.Result as ViewResult).Model;
            model.EmpName = "Mr " + model.EmpName;
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}