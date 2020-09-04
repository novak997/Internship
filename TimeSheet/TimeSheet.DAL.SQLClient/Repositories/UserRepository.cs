using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;

namespace TimeSheet.DAL.SQLClient.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=timesheet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddUser(User user)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
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
            command.ExecuteNonQuery();
        }

        public void ChangePassword(string password, int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspChangePassword", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public void DeleteUserLogically(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspDeleteUserLogically", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public void DeleteUserPhysically(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspDeleteUserPhysically", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using SqlConnection connection = new SqlConnection(_connectionString);
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

        public User GetUserById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
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

        public void UpdateUser(User user)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
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

        public User GetUserByUsername(string username)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
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

        public User GetUserByEmail(string email)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
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
    }
}
