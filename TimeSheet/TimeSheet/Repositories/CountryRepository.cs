using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using System.Data;
using TimeSheet.Context;
using Microsoft.EntityFrameworkCore;

namespace TimeSheet.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DatabaseContext _context;

        public CountryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddCountry(Country country)
        {
            _context.Database.ExecuteSqlRaw("exec dbo.uspAddCountry {0}, {1}", country.Name, country.Short);
        }
    }
}
