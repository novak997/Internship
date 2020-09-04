using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;

namespace TimeSheet.DAL.SQLClient.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int AddUser(User user)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspAddUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@weekly", user.Weekly);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@isActive", user.IsActive);
                command.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
                command.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                return (Convert.ToInt32(command.Parameters["@newId"].Value));
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void ChangePassword(string password, int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspChangePassword", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void DeleteUserLogically(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspDeleteUserLogically", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void DeleteUserPhysically(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspDeleteUserPhysically", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                List<User> users = new List<User>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetAllUsers", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User()
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Weekly = Convert.ToDouble(reader["weekly"]),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        IsActive = Convert.ToBoolean(reader["isActive"]),
                        IsAdmin = Convert.ToBoolean(reader["isAdmin"]),
                        IsDeleted = Convert.ToBoolean(reader["isDeleted"])
                    };
                    users.Add(user);
                }
                return users;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public User GetUserById(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetUserById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                while (reader.Read())
                {
                    user.ID = Convert.ToInt32(reader["id"]);
                    user.Weekly = Convert.ToDouble(reader["weekly"]);
                    user.Name = reader["name"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.IsActive = Convert.ToBoolean(reader["isActive"]);
                    user.IsAdmin = Convert.ToBoolean(reader["isAdmin"]);
                    user.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                }
                return user;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void UpdateUser(User user)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspUpdateUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@weekly", user.Weekly);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@isActive", user.IsActive);
                command.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
                command.Parameters.AddWithValue("@id", user.ID);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetUserByUsername", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                while (reader.Read())
                {
                    user.ID = Convert.ToInt32(reader["id"]);
                    user.Weekly = Convert.ToDouble(reader["weekly"]);
                    user.Name = reader["name"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.IsActive = Convert.ToBoolean(reader["isActive"]);
                    user.IsAdmin = Convert.ToBoolean(reader["isAdmin"]);
                    user.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                }
                return user;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetUserByEmail", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                while (reader.Read())
                {
                    user.ID = Convert.ToInt32(reader["id"]);
                    user.Weekly = Convert.ToDouble(reader["weekly"]);
                    user.Name = reader["name"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.IsActive = Convert.ToBoolean(reader["isActive"]);
                    user.IsAdmin = Convert.ToBoolean(reader["isAdmin"]);
                    user.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                }
                return user;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
    }
}
