using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Models;
using TimeSheet.Repositories;
using TimeSheet.Services;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService = new CategoryService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCategory([FromBody] Category category)
        {
            return Json(_categoryService.AddCategory(category));
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            return Json(_categoryService.GetAllCategories());
        }

        [HttpGet("{id}")]
        public JsonResult GetCategoryById(int id)
        {
            return Json(_categoryService.GetCategoryById(id));
        }
    }
}
