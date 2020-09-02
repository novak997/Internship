using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Models;
using TimeSheet.Repositories;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly CountryRepository _countryRepository;
        public CountryController(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void AddCountry([FromBody] Country country)
        {
            _countryRepository.AddCountry(country);
        }
    }
}
