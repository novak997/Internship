using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;

namespace TimeSheet.DAL.SQLClient.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int AddCategory(Category category)
        {
            try 
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspAddCategory", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@name", category.Name);
                command.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                return (Convert.ToInt32(command.Parameters["@newId"].Value));
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetCategoryById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                Category category = new Category();
                while (reader.Read())
                {
                    category.ID = Convert.ToInt32(reader["id"]);
                    category.Name = reader["name"].ToString();
                }
                return category;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                List<Category> categories = new List<Category>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetAllCategories", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category()
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString()
                    };
                    categories.Add(category);
                }
                return categories;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
        public Category GetCategoryByName(string name)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetCategoryByName", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = command.ExecuteReader();
                Category category = new Category();
                while (reader.Read())
                {
                    category.ID = Convert.ToInt32(reader["id"]);
                    category.Name = reader["name"].ToString();
                }
                return category;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }

        }
    }
}
