using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Services;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCategory([FromBody] Category category)
        {
            try
            {
                return Json(_categoryService.AddCategory(category));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            try
            {
                return Json(_categoryService.GetAllCategories());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public JsonResult GetCategoryById(int id)
        {
            try
            {
                return Json(_categoryService.GetCategoryById(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
    }
}
