using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=timesheet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddCategory(Category category)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspAddCategory", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", category.Name);
            command.ExecuteNonQuery();
        }

        public Category GetCategoryById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
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

        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            using SqlConnection connection = new SqlConnection(_connectionString);
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
        public Category GetCategoryByName(string name)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
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
    }
}
