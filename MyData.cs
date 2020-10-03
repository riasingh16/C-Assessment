using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class MyData
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }

        public override string ToString()
        {

            return $"The EmployeeID:{EmployeeID}<p>The name:{EmployeeName}<p>The Employee Address:{EmployeeAddress}<p><p>";
        }


    }
}