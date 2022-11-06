using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)

        {
            var Conn = configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(Conn));
            return services;
           
        }
    }
}
//option=>option.UseOracleSQLCompatibility("11")