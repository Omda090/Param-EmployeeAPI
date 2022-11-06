using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces
{
   public interface IUserlogin
    {
        Task<Userlogin> Register(Userlogin user, string Password);
        Task<Userlogin> Login(int UserId, string UserName, string Password);
        Task<bool> UserExits(string UserName);

        Task<Userlogin> GetById(int id);
        Task<IEnumerable<Userlogin>> GetAll();
        void Add(Userlogin entity);
        void Remove(Userlogin entity);
        Task<bool> SaveChanges();

    }
}
