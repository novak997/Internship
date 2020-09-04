using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Business.Contracts.Services
{
    public interface ICountryService
    {
        public string AddCountry(Country country);
        public Country GetCountryById(int id);
        public IEnumerable<Country> GetAllCountries();
    }
}
