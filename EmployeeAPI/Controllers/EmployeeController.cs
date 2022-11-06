using AutoMapper;
using EmployeeAPI.DTOs;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;


        public EmployeeController(IEmployee employee, IMapper mapper)
        {
            _employee = employee;
            _mapper = mapper;
        }

        [HttpGet("Empolyees")]
        public async Task<IActionResult> Get()
        {
            var items = await _employee.GetAll();
            return Ok(items);
        }

        [HttpGet("GetEmpById")]
        public async Task<IActionResult> GetById(int id)
        {

            return Ok(await _employee.GetById(id));
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmp(EmployeeDto employee)
        {
            var emp = _mapper.Map<Employee>(employee);

             _employee.Add(emp);
            await _employee.SaveChanges();
            return Ok(emp);

        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            var exitsEmp = await _employee.GetById(id);


            //check if Emp exit or not 
            if (exitsEmp != null)
            {

                //save changes
                _employee.Remove(exitsEmp);
                await _employee.SaveChanges();
                return Ok("employee Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmp(int id, Employee employee)
        {
            var exitsEmp = await _employee.GetById(id);

            //Update employee Detials
            exitsEmp.FullName = employee.FullName;
            exitsEmp.Address = employee.Address;
            exitsEmp.Branch = employee.Branch;
            exitsEmp.JobTitle = employee.JobTitle;
            exitsEmp.PhoneNo = employee.PhoneNo;

            //Save Changes
            await _employee.SaveChanges();

            return Ok(" employee Updated Successfully ");
        }
    }
}
