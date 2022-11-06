using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.DTOs
{
    public class UserRoleDto
    {
        public int? id { get; set; }

        public virtual Role Role { get; set; }
        public virtual Userlogin User { get; set; }
    }
}
