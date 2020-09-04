using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Business.Services;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly CountryService _countryService = new CountryService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCountry([FromBody] Country country)
        {
            return Json(_countryService.AddCountry(country));
        }
        
        [HttpGet]
        public JsonResult GetAllCountries()
        {
            return Json(_countryService.GetAllCountries());
        }
        
    }
}
