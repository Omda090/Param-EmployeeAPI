using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public partial class UserRole : IdentityUserRole<int>
    {
        public int id { get; set; }

        public virtual Role Role { get; set; }
        public virtual Userlogin User { get; set; }
    }
}
