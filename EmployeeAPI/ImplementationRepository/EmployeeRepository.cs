using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.ImplementationRepository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Employee entity)
        {
            _context.Set<Employee>().AddAsync(entity);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Set<Employee>().ToListAsync();
        }

      

        public async Task<Employee> GetById(int id)
        {
            return await _context.employees.FirstOrDefaultAsync(Employee => Employee.id == id);
        }

        public void Remove(Employee exitsEmp)
        {
            _context.Remove(exitsEmp);
        }

        public async Task<bool> SaveChanges()
        {

            return await _context.SaveChangesAsync() > 0;
        }

        //public async Task<Employee> CreateEmpAsync(Employee employee)
        //{
        //    var Plus =await _context.employees.AddAsync(employee);
        //    _context.SaveChanges();
        //    return Plus;
        //}
    }
}
