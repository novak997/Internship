﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    interface ICountryRepository
    {
        public void AddCountry(Country country);
        public IEnumerable<Country> GetAllCountries();
        public Country GetCountryById(int id);
        public Country GetCountryByName(string name);
        public Country GetCountryByShort(string shortName);
    }
}
