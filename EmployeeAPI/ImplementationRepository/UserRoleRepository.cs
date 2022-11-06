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
    public class UserRoleRepository : IUserRole
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(UserRole entity)
        {
            _context.Set<UserRole>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<UserRole> entities)
        {
            _context.Set<UserRole>().AddRange(entities);
        }

        public async Task<IEnumerable<UserRole>> GetAll()
        {
            return await _context.Set<UserRole>().ToListAsync();
        }

        public async Task<UserRole> GetById(int id)
        {
            return await _context.Set<UserRole>().FindAsync(id);
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesData()
        {
            return await _context.Set<UserRole>().ToListAsync();
        }

        public void Remove(UserRole entity)
        {
            _context.Set<UserRole>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<UserRole> entities)
        {
            _context.Set<UserRole>().RemoveRange(entities);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(int Id, UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
