using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public partial class Role : IdentityRole<int>
    {
        public Role()
        {

            UserRoles = new HashSet<UserRole>();
        }


        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
