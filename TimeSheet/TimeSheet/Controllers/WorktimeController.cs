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
    public class WorktimeController : Controller
    {
        private readonly WorktimeService _worktimeService = new WorktimeService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddWorktime([FromBody] Worktime worktime)
        {
            return Json(_worktimeService.AddWorktime(worktime));
        }

        [HttpGet("id")]
        public JsonResult GetWorktimesForUser(int id)
        {
            return Json(_worktimeService.GetWorktimesForUser(id));
        }

        [HttpPost("filter")]
        public JsonResult FilterReports([FromBody] WorktimeFilterDTO worktimeFilterDTO)
        {
            return Json(_worktimeService.FilterReports(worktimeFilterDTO));
        }
    }
}
