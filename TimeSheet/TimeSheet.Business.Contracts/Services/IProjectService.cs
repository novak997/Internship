using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Business.Contracts.Services
{
    public interface IProjectService
    {
        public string AddProject(Project project);
        public IEnumerable<Project> GetAllProjects();
        public Project GetProjectById(int id);
        public string UpdateProject(Project project);
        public string DeleteProjectLogically(int id);
        public IEnumerable<Project> SearchProjects(string name);
        public IEnumerable<string> GetProjectsFirstLetters();
        public IEnumerable<Project> GetProjectsByClient(int client);
    }
}
