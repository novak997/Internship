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
    public class WorktimeRepository : IWorktimeRepository
    {
        private readonly IConfiguration _configuration;

        public WorktimeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int AddWorktime(Worktime worktime)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspAddWorktime", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@description", worktime.Description);
                command.Parameters.AddWithValue("@hours", worktime.Hours);
                command.Parameters.AddWithValue("@overtime", worktime.Overtime);
                command.Parameters.AddWithValue("@date", worktime.Date);
                command.Parameters.AddWithValue("@client", worktime.ClientID);
                command.Parameters.AddWithValue("@project", worktime.ProjectID);
                command.Parameters.AddWithValue("@category", worktime.CategoryID);
                command.Parameters.AddWithValue("@user", worktime.UserID);
                command.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                return (Convert.ToInt32(command.Parameters["@newId"].Value));
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void UpdateWorktime(Worktime worktime)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspUpdateWorktime", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@description", worktime.Description);
                command.Parameters.AddWithValue("@hours", worktime.Hours);
                command.Parameters.AddWithValue("@overtime", worktime.Overtime);
                command.Parameters.AddWithValue("@client", worktime.ClientID);
                command.Parameters.AddWithValue("@project", worktime.ProjectID);
                command.Parameters.AddWithValue("@category", worktime.CategoryID);
                command.Parameters.AddWithValue("@id", worktime.ID);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }

        }

        public IEnumerable<Worktime> GetWorktimesForUser(int id)
        {
            try
            {
                List<Worktime> worktimes = new List<Worktime>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetWorktimesForUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Worktime worktime = new Worktime()
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Description = reader["description"].ToString(),
                        Hours = Convert.ToDouble(reader["hours"]),
                        Overtime = Convert.ToDouble(reader["overtime"]),
                        Date = Convert.ToDateTime(reader["date"]),
                        ClientID = Convert.ToInt32(reader["clientID"]),
                        ProjectID = Convert.ToInt32(reader["projectID"]),
                        CategoryID = Convert.ToInt32(reader["categoryID"]),
                        UserID = Convert.ToInt32(reader["userID"]),
                    };
                    worktimes.Add(worktime);
                }
                return worktimes;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public IEnumerable<Worktime> GetWorktimesForUserAndDate(int id, DateTime date)
        {
            try
            {
                List<Worktime> worktimes = new List<Worktime>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetWorktimesForUserAndDate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@date", date);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Worktime worktime = new Worktime()
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Description = reader["description"].ToString(),
                        Hours = Convert.ToDouble(reader["hours"]),
                        Overtime = Convert.ToDouble(reader["overtime"]),
                        Date = Convert.ToDateTime(reader["date"]),
                        ClientID = Convert.ToInt32(reader["clientID"]),
                        ProjectID = Convert.ToInt32(reader["projectID"]),
                        CategoryID = Convert.ToInt32(reader["categoryID"]),
                        UserID = Convert.ToInt32(reader["userID"]),
                    };
                    worktimes.Add(worktime);
                }
                return worktimes;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }

        }

        public double GetWorktimesTotalHours(int id, DateTime date)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetWorktimesTotalHours", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@date", date);
                SqlDataReader reader = command.ExecuteReader();
                double sum = 0;
                while (reader.Read())
                {
                    try
                    {
                        sum = Convert.ToDouble(reader["totalHours"]);
                    }
                    catch
                    {
                        sum = 0;
                    }

                }
                return sum;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public IEnumerable<Worktime> FilterReports(int user, int client, int project, int category, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Worktime> worktimes = new List<Worktime>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetWorktimesForUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@client", client);
                command.Parameters.AddWithValue("@project", project);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@endDate", endDate);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Worktime worktime = new Worktime()
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Description = reader["description"].ToString(),
                        Hours = Convert.ToDouble(reader["hours"]),
                        Overtime = Convert.ToDouble(reader["overtime"]),
                        Date = Convert.ToDateTime(reader["date"]),
                        ClientID = Convert.ToInt32(reader["clientID"]),
                        ProjectID = Convert.ToInt32(reader["projectID"]),
                        CategoryID = Convert.ToInt32(reader["categoryID"]),
                        UserID = Convert.ToInt32(reader["userID"]),
                    };
                    worktimes.Add(worktime);
                }
                return worktimes;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
    }
}
