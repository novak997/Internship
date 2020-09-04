using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Services;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddUser([FromBody] User user)
        {
            try
            {
                return Json(_userService.AddUser(user));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPut("resetpassword")]
        public JsonResult ResetPassword([FromBody] JObject dto)
        {
            try
            {
                return Json(_userService.ResetPassword(dto["oldPassword"].ToString(), dto["newPassword"].ToString(), dto["newPasswordConfirm"].ToString(), Convert.ToInt32(dto["id"])));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPut("setpassword")]
        public JsonResult SetPassword([FromBody] JObject dto)
        {
            try
            {
                return Json(_userService.SetPassword(dto["password"].ToString(), Convert.ToInt32(dto["id"])));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public JsonResult DeleteUserLogically(int id)
        {
            try
            {
                return Json(_userService.DeleteUserLogically(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            try
            {
                return Json(_userService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public JsonResult GetUserById(int id)
        {
            try
            {
                return Json(_userService.GetUserById(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPut]
        public JsonResult UpdateUser([FromBody] User user)
        {
            try
            {
                return Json(_userService.UpdateUser(user));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
    }
}
