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
    public class ProjectRepository : IProjectRepository
    {
        private readonly IConfiguration _configuration;

        public ProjectRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int AddProject(Project project)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspAddProject", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@name", project.Name);
                command.Parameters.AddWithValue("@description", project.Description);
                command.Parameters.AddWithValue("@client", project.ClientID);
                command.Parameters.AddWithValue("@lead", project.LeadID);
                command.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                return (Convert.ToInt32(command.Parameters["@newId"].Value));
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void DeleteProjectLogically(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspDeleteProjectLogically", connection)
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

        public void DeleteProjectPhysically(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspDeleteProjectPhysically", connection)
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

        public IEnumerable<Project> GetAllProjects()
        {
            try
            {
                List<Project> projects = new List<Project>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
                        ClientID = Convert.ToInt32(reader["clientID"]),
                        LeadID = Convert.ToInt32(reader["leadID"]),
                        IsDeleted = Convert.ToBoolean(reader["isDeleted"])
                    };
                    projects.Add(project);
                }
                return projects;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public Project GetProjectById(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
                    project.ClientID = Convert.ToInt32(reader["clientID"]);
                    project.LeadID = Convert.ToInt32(reader["leadID"]);
                    project.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                }
                return project;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
        
        public IEnumerable<string> GetProjectsFirstLetters()
        {
            try
            {
                List<string> letters = new List<string>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
        
        public IEnumerable<Project> SearchProjects(string query)
        {
            try
            {
                List<Project> projects = new List<Project>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspSearchProjects", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@query", query);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Project project = new Project()
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Description = reader["description"].ToString(),
                        Status = reader["status"].ToString(),
                        ClientID = Convert.ToInt32(reader["clientID"]),
                        LeadID = Convert.ToInt32(reader["leadID"]),
                        IsDeleted = Convert.ToBoolean(reader["isDeleted"])
                    };
                    projects.Add(project);
                }
                return projects;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void UpdateProject(Project project)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public Project GetProjectByNameAndClient(string name, int client)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
                    project.ClientID = Convert.ToInt32(reader["clientID"]);
                    project.LeadID = Convert.ToInt32(reader["leadID"]);
                    project.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                }
                return project;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public IEnumerable<Project> GetProjectsByClient(int client)
        {
            try
            {
                List<Project> projects = new List<Project>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspGetProjectsByClient", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@client", client);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Project project = new Project()
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Description = reader["description"].ToString(),
                        Status = reader["status"].ToString(),
                        ClientID = Convert.ToInt32(reader["clientID"]),
                        LeadID = Convert.ToInt32(reader["leadID"]),
                        IsDeleted = Convert.ToBoolean(reader["isDeleted"])
                    };
                    projects.Add(project);
                }
                return projects;
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
        }

        
    }
}
