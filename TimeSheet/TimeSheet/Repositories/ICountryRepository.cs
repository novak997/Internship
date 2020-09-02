using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    interface ICountryRepository
    {
        public void AddCountry(Country country);
    }
}
