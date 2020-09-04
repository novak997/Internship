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
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCountry([FromBody] Country country)
        {
            try
            {
                return Json(_countryService.AddCountry(country));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
        
        [HttpGet]
        public JsonResult GetAllCountries()
        {
            try
            {
                return Json(_countryService.GetAllCountries());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
        
    }
}
