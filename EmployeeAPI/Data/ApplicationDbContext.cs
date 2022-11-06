using EmployeeAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<Userlogin, Role, int, IdentityUserClaim<int>
        , UserRole, Microsoft.AspNetCore.Identity.IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            //....
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>(userRole =>

            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

                userRole.HasOne(ur => ur.User)
               .WithMany(r => r.UserRoles)
               .HasForeignKey(ur => ur.UserId)
               .IsRequired();

            });
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Userlogin> userlogins { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



    }
}
