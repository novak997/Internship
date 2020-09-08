using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Exceptions;
using TimeSheet.Business.Services;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;

namespace TimeSheet.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                return Ok(_categoryService.AddCategory(category));
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

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                return Ok(_categoryService.GetAllCategories());
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

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                return Ok(_categoryService.GetCategoryById(id));
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
