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
        public IEnumerable<Project> SearchProjects(string name, int page, int number);
        public IEnumerable<string> GetProjectsFirstLetters();
        public IEnumerable<Project> GetProjectsByClient(int client);
        public int GetNumberOfProjects();
        public int GetNumberOfFilteredProjects(string name);
        public IEnumerable<Project> GetProjectsByPage(int page, int number);
    }
}
