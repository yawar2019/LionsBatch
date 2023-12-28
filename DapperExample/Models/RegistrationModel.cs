using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DapperExample.Models
{
    public class RegistrationModel
    {
        [Display(Name ="Employee Name")]
        public string EmpName { get; set; }
        [DataType(DataType.Time)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public bool AcceptAgreement { get; set; }
        public string Country { get; set; }
        [ScaffoldColumn(true)]
        public string Address { get; set; }
    }
}
