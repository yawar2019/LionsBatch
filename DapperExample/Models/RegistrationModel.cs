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
        [Required(ErrorMessage ="EmpName Cannot be empty")]
        public string EmpName { get; set; }
       
        [Required(ErrorMessage = "Password Cannot be empty")]
        [StringLength(10,ErrorMessage ="Atleast 10 Characters Mandatory")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Mismatch of Compare pwd and password")]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        [Required]
        public bool AcceptAgreement { get; set; }
        public string Country { get; set; }
        [Range(18,60,ErrorMessage ="18-60 ageyou can enter")]
        public int age { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Email address is Invalid")]
        public string EmailAddress { get; set; }
        public string Address { get; set; }
    }
}
