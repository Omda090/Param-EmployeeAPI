using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Branch { get; set; }
        public string JobTitle { get; set; }
        public int PhoneNo { get; set; }
    }
}
