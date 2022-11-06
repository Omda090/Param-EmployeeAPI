using AutoMapper;
using DTOs;
using EmployeeAPI.DTOs;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Mapping
{
    public class AutoMapper:Profile
    {

        public AutoMapper()
        {
            CreateMap<Employee,EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();


            CreateMap<Userlogin, UserForDetailsDto>();
            CreateMap<UserForDetailsDto, Userlogin>();

            CreateMap<Userlogin, UserForRegisterDto>();
            CreateMap<UserForRegisterDto, Userlogin>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();

        }
    }
}
