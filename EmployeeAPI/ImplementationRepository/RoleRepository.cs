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
    public class RoleRepository : IRole
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Role entity)
        {
            _context.Set<Role>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<Role> entities)
        {
            _context.Set<Role>().AddRange(entities);
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Set<Role>().ToListAsync();
        }



        public async Task<Role> GetById(int id)
        {
            return await _context.Set<Role>().FindAsync(id);
        }

        public void Remove(Role entity)
        {
            _context.Set<Role>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Role> entities)
        {
            _context.Set<Role>().RemoveRange(entities);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(decimal Id, Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
