using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.DAL.Entities;

namespace TimeSheet.DAL.Contracts.Repositories
{
    public interface IProjectRepository
    {
        public int AddProject(Project project);
        public IEnumerable<Project> GetAllProjects();
        public Project GetProjectById(int id);
        public void UpdateProject(Project project);
        public void DeleteProjectPhysically(int id);
        public void DeleteProjectLogically(int id);
        public IEnumerable<Project> SearchProjects(string name, int page, int number);
        public IEnumerable<string> GetProjectsFirstLetters();
        public Project GetProjectByNameAndClient(string name, int client);
        public IEnumerable<Project> GetProjectsByClient(int client);
        public IEnumerable<Project> GetProjectsByPage(int page, int number);
        public int GetNumberOfProjects();
        public int GetNumberOfFilteredProjects(string name);
    }
}
