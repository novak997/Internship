using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Controllers.DTO;
using TimeSheet.Models;
using TimeSheet.Repositories;
using TimeSheet.Services;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _userService = new UserService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddUser([FromBody] User user)
        {
            return Json(_userService.AddUser(user));
        }

        [HttpPut("resetpassword")]
        public JsonResult ResetPassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            return Json(_userService.ResetPassword(changePasswordDTO));
        }

        [HttpPut("setpassword")]
        public JsonResult SetPassword([FromBody] SetPasswordDTO setPasswordDTO)
        {
            return Json(_userService.SetPassword(setPasswordDTO));
        }

        [HttpPut("{id}")]
        public void DeleteUserLogically(int id)
        {
            _userService.DeleteUserLogically(id);
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            return Json(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public JsonResult GetUserById(int id)
        {
            return Json(_userService.GetUserById(id));
        }

        [HttpPut]
        public JsonResult UpdateUser([FromBody] User user)
        {
            return Json(_userService.UpdateUser(user));
        }
    }
}
