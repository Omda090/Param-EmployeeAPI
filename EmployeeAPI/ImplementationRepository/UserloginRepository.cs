using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.ImplementationRepository
{
    public class UserloginRepository : IUserlogin
    {
        private readonly ApplicationDbContext _context;

        public UserloginRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void Add(Userlogin entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Userlogin>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Userlogin> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Userlogin> Login(int UserId, string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<Userlogin> Register(Userlogin user, string Password)
        {
            throw new NotImplementedException();
        }

        public void Remove(Userlogin entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
