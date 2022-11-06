using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Userlogin> Login(int UserId, string UserName, string Password)
        {
            var user = await _context.userlogins.FirstOrDefaultAsync(x => x.Id == UserId);
            if (user == null)
                return null;
            return user;
        }

        public async Task<Userlogin> Register(Userlogin user, string Password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(Password, out passwordHash, out passwordSalt);
            await _context.userlogins.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> UserExits(string UserName)
        {
            if (await _context.userlogins.AnyAsync(x => x.UserName == UserName))
                return true;
            return false;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
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
