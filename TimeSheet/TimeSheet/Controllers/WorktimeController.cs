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
    public class WorktimeController : Controller
    {
        private readonly IWorktimeService _worktimeService;

        public WorktimeController(IWorktimeService worktimeService)
        {
            _worktimeService = worktimeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddWorktime([FromBody] Worktime worktime)
        {
            try
            {
                return Json(_worktimeService.AddWorktime(worktime));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet("id")]
        public JsonResult GetWorktimesForUser(int id)
        {
            try
            {
                return Json(_worktimeService.GetWorktimesForUser(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPost("filter")]
        public JsonResult FilterReports([FromBody] JObject dto)
        {
            try
            {
                return Json(_worktimeService.FilterReports(Convert.ToInt32(dto["user"]), Convert.ToInt32(dto["client"]), Convert.ToInt32(dto["project"]), Convert.ToInt32(dto["category"]),
                Convert.ToDateTime(dto["startDate"]), Convert.ToDateTime(dto["endDate"])));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
    }
}
