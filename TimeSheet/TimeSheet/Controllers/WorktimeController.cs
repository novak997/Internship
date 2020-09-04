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
        public JsonResult FilterReports([FromBody] JObject dto)
        {
            return Json(_worktimeService.FilterReports(Convert.ToInt32(dto["user"]), Convert.ToInt32(dto["client"]), Convert.ToInt32(dto["project"]), Convert.ToInt32(dto["category"]), 
                Convert.ToDateTime(dto["startDate"]), Convert.ToDateTime(dto["endDate"])));
        }
    }
}
