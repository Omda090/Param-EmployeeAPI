
using AutoMapper;
using EmployeeAPI.DTOs;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserloginController : ControllerBase
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUserlogin _repo;
        private readonly UserManager<Userlogin> _userManager;
        private readonly SignInManager<Userlogin> _signInManager;


        public UserloginController(Microsoft.Extensions.Configuration.IConfiguration config, IMapper mapper, IUserlogin userlogin,
            UserManager<Userlogin> userManager, SignInManager<Userlogin> signInManager)
        {
            _config = config;
            _mapper = mapper;
            _repo = userlogin;
            _userManager = userManager;
            _signInManager = signInManager;


        }



        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetById(int id)
        {
            var singleUser = await _repo.GetById(id);

            //Check if variable is null or not
            if (singleUser != null)
                return Ok(singleUser);

            return BadRequest("User Not Found");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserloginDto userloginnDto)
        {
            var user = await _userManager.FindByNameAsync(userloginnDto.UserName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, userloginnDto.Password, false);

            if (result.Succeeded)
            {
                var AppUser = _userManager.Users
                    .FirstOrDefault(u => u.NormalizedUserName == userloginnDto.UserName.ToUpper());
                return Ok(new
                {
                    Token = GenerateJwtTokem(AppUser).Result
                });
            }
            return Unauthorized();

        }

        private async Task<string> GenerateJwtTokem(Userlogin userlogin)
        {
            var claims = new List<Claim>
          {
             new Claim(ClaimTypes.Name,userlogin.UserName.ToString()),
            new Claim(ClaimTypes.SerialNumber,userlogin.Nameen.ToString()),
            new Claim(ClaimTypes.NameIdentifier,userlogin.Id.ToString()),
              new Claim(JwtRegisteredClaimNames.UniqueName,userlogin.UserName.ToString()),

             };
            var roles = await _userManager.GetRolesAsync(userlogin);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                      .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var TokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var Token = TokenHandler.CreateToken(TokenDesc);
            return TokenHandler.WriteToken(Token);
        }

        [HttpPut("UpdatUser")]
        public async Task<IActionResult> UpdatUser(int id, UserloginDto userDto)
        {
            //Get State From Database
            var dbUser = await _repo.GetById(id);
            if (dbUser == null)
                return BadRequest("User Not Found");
            //Update State Details
            dbUser.UserName = userDto.UserName;
            dbUser.Nameen = userDto.Nameen;
            dbUser.Password = userDto.Password;

            //Save Changes
            await _repo.SaveChanges();

            return Ok("User Updated Successfully ");
        }

        [HttpPut("UpdateUserDeleted")]
        public async Task<IActionResult> UpdateUserDeleted([FromQuery] int id)
        {
            //Get User From Database
            var dbUser = await _repo.GetById(id);

            if (dbUser == null)
                return BadRequest("User Not Found");
            //Update User Status to Deleted
            dbUser.UserName = "Deleted";

            //Save Changes
            await _repo.SaveChanges();

            return Ok("User Updated Successfully ");
        }

    }
}
