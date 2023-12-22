using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
 
namespace CodeFirstApproach.Models
{
    public class EmployeeContext: DbContext
    {

        public EmployeeContext():base("sqlcon")
        {
            
        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<DepartmentModel> DepartmentModels { get; set; }
    }
}

//if you are updating a new table follow this steps
//1)create a class andadd property to it
//2)come to Context class and add tabe property to it 
//3) type a)add-Migration DepartmentTable b)update-database