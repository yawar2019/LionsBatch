using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class DepartmentModel
    {

        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}