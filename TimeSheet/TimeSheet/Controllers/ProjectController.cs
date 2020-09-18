using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Exceptions;
using TimeSheet.Business.Services;
using TimeSheet.Controllers.DTO;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;

namespace TimeSheet.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] Project project)
        {
            try
            {
                return Ok(_projectService.AddProject(project));
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

        [HttpPut("{id}")]
        public IActionResult DeleteProjectLogically(int id)
        {
            try
            {
                return Ok(_projectService.DeleteProjectLogically(id));
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
        public IActionResult GetAllProjects()
        {
            try
            {
                return Ok(_projectService.GetAllProjects());
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
        public IActionResult GetProjectById(int id)
        {
            try
            {
                return Ok(_projectService.GetProjectById(id));
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

        [HttpGet("letters")]
        public IActionResult GetProjectsFirstLetters()
        {
            try
            {
                return Ok(_projectService.GetProjectsFirstLetters());
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

        [HttpPost("search")]
        public IActionResult SearchProjects([FromBody] SearchDTO search)
        {
            try
            {
                return Ok(_projectService.SearchProjects(search.Name, search.Page, search.Number));
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

        [HttpPut]
        public IActionResult UpdateProject([FromBody] Project project)
        {
            try
            {
                return Ok(_projectService.UpdateProject(project));
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

        [HttpGet("client/{id}")]
        public IActionResult GetProjectsByClient(int id)
        {
            try
            {
                return Ok(_projectService.GetProjectsByClient(id));
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

        [HttpGet("number")]
        public IActionResult GetNumberOfProjects()
        {
            try
            {
                return Ok(_projectService.GetNumberOfProjects());
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

        [HttpPost("number")]
        public IActionResult GetNumberOfFilteredProjects([FromBody] SearchDTO search)
        {
            try
            {
                return Ok(_projectService.GetNumberOfFilteredProjects(search.Name));
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

        [HttpGet("{page}/{number}")]
        public IActionResult GetProjectsByPage(int page, int number)
        {
            try
            {
                return Ok(_projectService.GetProjectsByPage(page, number));
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
