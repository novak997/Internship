using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;

namespace TimeSheet.DAL.SQLClient.Repositories
{
    public class WorktimeRepository : IWorktimeRepository
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=timesheet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddWorktime(Worktime worktime)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
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
            command.ExecuteNonQuery();
        }

        public IEnumerable<Worktime> GetWorktimesForUser(int id)
        {
            List<Worktime> worktimes = new List<Worktime>();
            using SqlConnection connection = new SqlConnection(_connectionString);
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
                    ClientID = Convert.ToInt32(reader["client"]),
                    ProjectID = Convert.ToInt32(reader["project"]),
                    CategoryID = Convert.ToInt32(reader["category"]),
                    UserID = Convert.ToInt32(reader["user"]),
                };
                worktimes.Add(worktime);
            }
            return worktimes;
        }

        public IEnumerable<Worktime> FilterReports(int user, int client, int project, int category, DateTime startDate, DateTime endDate)
        {
            List<Worktime> worktimes = new List<Worktime>();
            using SqlConnection connection = new SqlConnection(_connectionString);
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
                    ClientID = Convert.ToInt32(reader["client"]),
                    ProjectID = Convert.ToInt32(reader["project"]),
                    CategoryID = Convert.ToInt32(reader["category"]),
                    UserID = Convert.ToInt32(reader["user"]),
                };
                worktimes.Add(worktime);
            }
            return worktimes;
        }
    }
}
