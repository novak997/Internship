using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Services;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddProject([FromBody] Project project)
        {
            try
            {
                return Json(_projectService.AddProject(project));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public JsonResult DeleteProjectLogically(int id)
        {
            try
            {
                return Json(_projectService.DeleteProjectLogically(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet]
        public JsonResult GetAllProjects()
        {
            try
            {
                return Json(_projectService.GetAllProjects());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public JsonResult GetProjectById(int id)
        {
            try
            {
                return Json(_projectService.GetProjectById(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet("letters")]
        public JsonResult GetProjectsFirstLetters()
        {
            try
            {
                return Json(_projectService.GetProjectsFirstLetters());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPost("{name}")]
        public JsonResult SearchProjects([FromBody] string name)
        {
            try
            {
                return Json(_projectService.SearchProjects(name));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPut]
        public JsonResult UpdateProject([FromBody] Project project)
        {
            try
            {
                return Json(_projectService.UpdateProject(project));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
    }
}
