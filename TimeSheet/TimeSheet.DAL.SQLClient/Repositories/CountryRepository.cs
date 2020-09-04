using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;
using Microsoft.Extensions.Configuration;

namespace TimeSheet.DAL.SQLClient.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IConfiguration _configuration;

        public CountryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int AddCountry(Country country)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspAddCountry", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@name", country.Name);
                command.Parameters.AddWithValue("@short", country.Short);
                command.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                return (Convert.ToInt32(command.Parameters["@newId"].Value));
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
        public IEnumerable<Country> GetAllCountries()
        {
            try
            {
                List<Country> countries = new List<Country>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public Country GetCountryById(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public Country GetCountryByName(string name)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public Country GetCountryByShort(string shortName)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
    }
}
