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
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService = new ProjectService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddProject([FromBody] Project project)
        {
            return Json(_projectService.AddProject(project));
        }

        [HttpPut("{id}")]
        public void DeleteProjectLogically(int id)
        {
            _projectService.DeleteProjectLogically(id);
        }

        [HttpGet]
        public JsonResult GetAllProjects()
        {
            return Json(_projectService.GetAllProjects());
        }

        [HttpGet("{id}")]
        public JsonResult GetProjectById(int id)
        {
            return Json(_projectService.GetProjectById(id));
        }

        [HttpGet("letters")]
        public JsonResult GetProjectsFirstLetters()
        {
            return Json(_projectService.GetProjectsFirstLetters());
        }

        [HttpPost("{name}")]
        public JsonResult SearchProjects([FromBody] string name)
        {
            return Json(_projectService.SearchProjects(name));
        }

        [HttpPut]
        public JsonResult UpdateProject([FromBody] Project project)
        {
            return Json(_projectService.UpdateProject(project));
        }
    }
}
