using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class CountryService : ICountryService
    {
        private readonly CountryRepository _countryRepository = new CountryRepository();

        public string AddCountry(Country country)
        {
            if (country.Name == "" || country.Name == null || country.Short == "" || country.Short == null)
            {
                return "Country name and short name cannot be empty";
            }
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
