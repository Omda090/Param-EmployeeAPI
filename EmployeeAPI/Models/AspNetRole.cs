using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public partial class AspNetRole : IdentityRole<int>
    {
        public AspNetRole()
        {

            AspNetUserRoles = new HashSet<AspNetUserRole>();
        }


        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    }
}
