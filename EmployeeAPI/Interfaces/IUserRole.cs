using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces
{
   public interface IUserRole 
    {
        Task<IEnumerable<UserRole>> GetUserRolesData();


        Task<UserRole> GetById(int id);
        Task<IEnumerable<UserRole>> GetAll();
        //   IEnumerable<Role> FindByCondition(Expression<Func<Role, bool>> expression);
        void Add(UserRole entity);
        void AddRange(IEnumerable<UserRole> entities);
        void Remove(UserRole entity);
        void RemoveRange(IEnumerable<UserRole> entities);
        Task<bool> SaveChanges();
        void Update(int Id, UserRole entity);
        //  Task<PagedList<Role>> GetPagedList(PaginationParams paginationParams);
    }
}
