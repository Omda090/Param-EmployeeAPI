using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces
{
   public interface IEmployee
    {
       // Task<List<Employee>> GetAllEmpAsync();


        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> GetById(int id);

      //  Task<Employee> CreateEmpAsync(Employee employee);
        void Remove(Employee exitsEmp);

        Task<bool> SaveChanges();
        void Add(Employee entity);
        // Task GetAllCarsAsync();
    }
}
