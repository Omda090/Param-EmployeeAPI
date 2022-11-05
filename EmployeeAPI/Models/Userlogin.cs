using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public partial class Userlogin : IdentityUser<int>
    {
       

        public string UserName { get; set; }
        public string Nameen { get; set; }
        public string Password { get; set; }
        public int? Healthunitid { get; set; }
    }
}
