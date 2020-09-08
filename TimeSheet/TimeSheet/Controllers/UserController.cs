using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Exceptions;
using TimeSheet.Business.Services;
using TimeSheet.Controllers.DTO;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;

namespace TimeSheet.Controllers
{
    [Authorize(Roles = "Admin, User")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login.Username, login.Password);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private User AuthenticateUser(string username, string password)
        {
            return _userService.Login(username, password);
        }

        private string RoleName(bool isAdmin)
        {
            if (isAdmin)
            {
                return "Admin";
            }
            return "User";
        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, RoleName(user.IsAdmin))
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                return Ok(_userService.AddUser(user));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
            catch (BusinessLayerException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("resetpassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDTO resetPassword)
        {
            try
            {
                return Ok(_userService.ResetPassword(resetPassword.OldPassword, resetPassword.NewPassword, resetPassword.NewPasswordConfirm, resetPassword.ID));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
            catch (BusinessLayerException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("setpassword")]
        public IActionResult SetPassword([FromBody] SetPasswordDTO setPassword)
        {
            try
            {
                return Ok(_userService.SetPassword(setPassword.Password, setPassword.ID));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
            catch (BusinessLayerException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult DeleteUserLogically(int id)
        {
            try
            {
                return Ok(_userService.DeleteUserLogically(id));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
            catch (BusinessLayerException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
            catch (BusinessLayerException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
            catch (BusinessLayerException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                return Ok(_userService.UpdateUser(user));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
            catch (BusinessLayerException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
