using AutoMapper;
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
        }

        public int CreateMap { get; }
    }
}
