using AutoMapper;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces
{
   public interface IRole 
    {
        Task<Role> GetById(int id);
        Task<IEnumerable<Role>> GetAll();
     //   IEnumerable<Role> FindByCondition(Expression<Func<Role, bool>> expression);
        void Add(Role entity);
        void AddRange(IEnumerable<Role> entities);
        void Remove(Role entity);
        void RemoveRange(IEnumerable<Role> entities);
        Task<bool> SaveChanges();
        void Update(decimal Id, Role entity);
        //  Task<PagedList<Role>> GetPagedList(PaginationParams paginationParams);
    }
}
