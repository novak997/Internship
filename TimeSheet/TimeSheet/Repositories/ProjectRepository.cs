using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using TimeSheet.Models;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Context;

namespace TimeSheet.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DatabaseContext _context;
        public ProjectRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddProject(Project project)
        {
            _context.Database.ExecuteSqlRaw("exec uspAddProject {0}, {1}, {2}, {3}", project.Name,
                project.Description, project.ClientID, project.LeadID);
        }

        public void DeleteProjectLogically(int id)
        {
            _context.Database.ExecuteSqlRaw("exec uspDeleteProjectLogically {0}", id);
        }

        public void DeleteProjectPhysically(int id)
        {
            _context.Database.ExecuteSqlRaw("exec uspDeleteProjectPhysically {0}", id);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Projects.FromSqlRaw("exec uspGetAllProjects").ToList();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.FromSqlRaw("exec uspGetProjectById {0}", id).FirstOrDefault();
        }
        /*
        public IEnumerable<string> GetProjectsFirstLetters()
        {
            List<string> letters = new List<string>();
            using SqlConnection connection = new SqlConnection(_connection);
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
        */
        public IEnumerable<Project> SearchProjects(string name)
        {
            return _context.Projects.FromSqlRaw("exec uspSearchProjects {0}", name).ToList();
        }

        public void UpdateProject(Project project)
        {
            _context.Database.ExecuteSqlRaw("exec uspUpdateProject {0}, {1}, {2}, {3}, {4}", project.Name,
                project.Description, project.ClientID, project.LeadID, project.ID);
        }
    }
}
