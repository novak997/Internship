using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Exceptions;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public string AddCountry(Country country)
        {
            try
            {
                if (country.Name == "" || country.Name == null || country.Short == "" || country.Short == null)
                {
                    throw new BusinessLayerException("Country name and short name cannot be empty");
                }
                if (_countryRepository.GetCountryByName(country.Name) != null)
                {
                    throw new BusinessLayerException("Country name taken");
                }
                if (_countryRepository.GetCountryByShort(country.Short) != null)
                {
                    throw new BusinessLayerException("Country short name taken");
                }
                _countryRepository.AddCountry(country);
                return "Country successfully added";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }

        public IEnumerable<Country> GetAllCountries()
        {
            try
            {
                return _countryRepository.GetAllCountries();
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public Country GetCountryById(int id)
        {
            try
            {
                return _countryRepository.GetCountryById(id);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
    }
}
