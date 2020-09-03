using System;
using System.Collections.Generic;
using System.Data;
using TimeSheet.Models;
using Microsoft.Data.SqlClient;

namespace TimeSheet.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=timesheet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddProject(Project project)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspAddProject", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", project.Name);
            command.Parameters.AddWithValue("@description", project.Description);
            command.Parameters.AddWithValue("@client", project.ClientID);
            command.Parameters.AddWithValue("@lead", project.LeadID);
            command.ExecuteNonQuery();
        }

        public void DeleteProjectLogically(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspDeleteProjectLogically", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public void DeleteProjectPhysically(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspDeleteProjectPhysically", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetAllProjects", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Project project = new Project()
                {
                    ID = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Description = reader["description"].ToString(),
                    Status = reader["status"].ToString(),
                    ClientID = Convert.ToInt32(reader["client"]),
                    LeadID = Convert.ToInt32(reader["lead"]),
                    IsDeleted = Convert.ToBoolean(reader["isDeleted"])
                };
                projects.Add(project);
            }
            return projects;
        }

        public Project GetProjectById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetProjectById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Project project = new Project();
            while (reader.Read())
            {
                project.ID = Convert.ToInt32(reader["id"]);
                project.Name = reader["name"].ToString();
                project.Description = reader["description"].ToString();
                project.Status = reader["status"].ToString();
                project.ClientID = Convert.ToInt32(reader["client"]);
                project.LeadID = Convert.ToInt32(reader["lead"]);
                project.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
            }
            return project;
        }
        
        public IEnumerable<string> GetProjectsFirstLetters()
        {
            List<string> letters = new List<string>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("uspGetProjectsFirstLetters", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                letters.Add(reader["letter"].ToString());
            }
            return letters;
        }
        
        public IEnumerable<Project> SearchProjects(string name)
        {
            List<Project> projects = new List<Project>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspSearchProjects", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Project project = new Project()
                {
                    ID = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Description = reader["description"].ToString(),
                    Status = reader["status"].ToString(),
                    ClientID = Convert.ToInt32(reader["client"]),
                    LeadID = Convert.ToInt32(reader["lead"]),
                    IsDeleted = Convert.ToBoolean(reader["isDeleted"])
                };
                projects.Add(project);
            }
            return projects;
        }

        public void UpdateProject(Project project)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspUpdateProject", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", project.Name);
            command.Parameters.AddWithValue("@description", project.Description);
            command.Parameters.AddWithValue("@client", project.ClientID);
            command.Parameters.AddWithValue("@lead", project.LeadID);
            command.Parameters.AddWithValue("@status", project.Status);
            command.Parameters.AddWithValue("@id", project.ID);
            command.ExecuteNonQuery();
        }

        public Project GetProjectByNameAndClient(string name, int client)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetProjectByNameAndClient", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@client", client);
            SqlDataReader reader = command.ExecuteReader();
            Project project = new Project();
            while (reader.Read())
            {
                project.ID = Convert.ToInt32(reader["id"]);
                project.Name = reader["name"].ToString();
                project.Description = reader["description"].ToString();
                project.Status = reader["status"].ToString();
                project.ClientID = Convert.ToInt32(reader["client"]);
                project.LeadID = Convert.ToInt32(reader["lead"]);
                project.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
            }
            return project;
        }
    }
}
