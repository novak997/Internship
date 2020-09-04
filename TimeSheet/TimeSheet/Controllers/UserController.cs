using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TimeSheet.Business.Services;
using TimeSheet.DAL.Entities;

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
        public JsonResult ResetPassword([FromBody] JObject dto)
        {
            return Json(_userService.ResetPassword(dto["oldPassword"].ToString(), dto["newPassword"].ToString(), dto["newPasswordConfirm"].ToString(), Convert.ToInt32(dto["id"])));
        }

        [HttpPut("setpassword")]
        public JsonResult SetPassword([FromBody] JObject dto)
        {
            return Json(_userService.SetPassword(dto["password"].ToString(), Convert.ToInt32(dto["id"])));
        }

        [HttpPut("{id}")]
        public JsonResult DeleteUserLogically(int id)
        {
            return Json(_userService.DeleteUserLogically(id));
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
