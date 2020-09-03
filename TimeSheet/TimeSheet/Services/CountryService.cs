using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using TimeSheet.Repositories;

namespace TimeSheet.Services
{
    public class CountryService
    {
        private readonly CountryRepository _countryRepository = new CountryRepository();

        public string AddCountry(Country country)
        {
            if (_countryRepository.GetCountryByName(country.Name).Name != null)
            {
                return "Country name taken";
            }
            if (_countryRepository.GetCountryByShort(country.Short).Name != null) 
            {
                return "Country short name taken";
            }
            _countryRepository.AddCountry(country);
            return "Country successfully added";
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _countryRepository.GetAllCountries();
        }
        public Country GetCountryById(int id)
        {
            return _countryRepository.GetCountryById(id);
        }
    }
}
