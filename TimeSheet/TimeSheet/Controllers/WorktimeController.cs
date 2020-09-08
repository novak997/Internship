using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class WorktimeController : Controller
    {
        private readonly IWorktimeService _worktimeService;

        public WorktimeController(IWorktimeService worktimeService)
        {
            _worktimeService = worktimeService;
        }

        [HttpPost]
        public IActionResult AddWorktime([FromBody] Worktime worktime)
        {
            try
            {
                return Ok(_worktimeService.AddWorktime(worktime));
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

        [HttpGet("id")]
        public IActionResult GetWorktimesForUser(int id)
        {
            try
            {
                return Ok(_worktimeService.GetWorktimesForUser(id));
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

        [HttpPost("filter")]
        public IActionResult FilterReports([FromBody] FilterReportsDTO filterReports)
        {
            try
            {
                return Ok(_worktimeService.FilterReports(filterReports.UserID, filterReports.ClientID, filterReports.ProjectID, filterReports.CategoryID, filterReports.StartDate, filterReports.EndDate));
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
