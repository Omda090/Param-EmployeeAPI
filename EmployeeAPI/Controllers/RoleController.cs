using AutoMapper;
using EmployeeAPI.DTOs;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _roles;
        private readonly IMapper _mapper;
        private readonly UserManager<Userlogin> _userManager;


        public RoleController(IRole roles, IMapper mapper, UserManager<Userlogin> userManager)
        {
            _roles = roles;
            _mapper = mapper;
            _userManager = userManager;

        }



        [HttpGet("RoleDetails")]
        public async Task<IActionResult> RoleDetails()
        {
            var ListOfRoles = await _roles.GetAll();
            return Ok(ListOfRoles);
        }

        [HttpGet("GetRoleById")]
        public async Task<IActionResult> GetRoleById(int Id)
        {
            var SingleRole = await _roles.GetById(Id);

            //Check if variable is null or not
            if (SingleRole != null)
                return Ok(SingleRole);

            return BadRequest("Role Not Found");

        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleDto roleDto)
        {
            try
            {

                var UnitToCreate = _mapper.Map<Role>(roleDto);
                UnitToCreate.NormalizedName = roleDto.Name.ToUpper();
                _roles.Add(UnitToCreate);

                await _roles.SaveChanges();
                return Ok("Role Created Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
