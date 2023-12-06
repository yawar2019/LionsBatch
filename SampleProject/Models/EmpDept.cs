using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProject.Models
{
    public class EmpDept
    {
        public List<EmployeeModel> emp { get; set; }
        public List<DeptModel> dept { get; set; }
    }
}