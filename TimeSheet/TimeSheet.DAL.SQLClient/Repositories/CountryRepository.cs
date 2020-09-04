using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;

namespace TimeSheet.DAL.SQLClient.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        //private readonly string conString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(this.Configuration, "Database");
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=timesheet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void AddCountry(Country country)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspAddCountry", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", country.Name);
            command.Parameters.AddWithValue("@short", country.Short);
            command.ExecuteNonQuery();
        }
        public IEnumerable<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetAllCountries", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Country country = new Country()
                {
                    ID = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Short = reader["short"].ToString()
                };
                countries.Add(country);
            }
            return countries;
        }

        public Country GetCountryById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetCountryById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Country country = new Country();
            while (reader.Read())
            {
                country.ID = Convert.ToInt32(reader["id"]);
                country.Name = reader["name"].ToString();
                country.Short = reader["short"].ToString();
            }
            return country;
        }

        public Country GetCountryByName(string name)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetCountryByName", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            Country country = new Country();
            while (reader.Read())
            {
                country.ID = Convert.ToInt32(reader["id"]);
                country.Name = reader["name"].ToString();
                country.Short = reader["short"].ToString();
            }
            return country;
        }

        public Country GetCountryByShort(string shortName)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetCountryByShort", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@short", shortName);
            SqlDataReader reader = command.ExecuteReader();
            Country country = new Country();
            while (reader.Read())
            {
                country.ID = Convert.ToInt32(reader["id"]);
                country.Name = reader["name"].ToString();
                country.Short = reader["short"].ToString();
            }
            return country;
        }
    }
}
