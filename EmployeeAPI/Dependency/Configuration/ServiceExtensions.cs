using EmployeeAPI.ImplementationRepository;
using EmployeeAPI.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Dependency.Configrations
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", x => x.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin());

            });
        }
        public static void ConfigureScoped(this IServiceCollection services)
        {
            #region Settings Interface
            services.AddScoped<IEmployee, EmployeeRepository>();
            services.AddScoped<IUserlogin, UserloginRepository>();

            //services.AddScoped<IRoleClaim, ClaimRoleRepository>();

            

            #endregion

    
        }
    }
}
