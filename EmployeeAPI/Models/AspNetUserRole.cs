using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public partial class AspNetUserRole : IdentityUserRole<int>
    {
        public int id { get; set; }

        public virtual AspNetRole Role { get; set; }
        public virtual Userlogin User { get; set; }
    }
}
