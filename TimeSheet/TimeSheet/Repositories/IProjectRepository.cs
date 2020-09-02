using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    interface IProjectRepository
    {
        public void AddProject(Project project);
        public IEnumerable<Project> GetAllProjects();
        public Project GetProjectById(int id);
        public void UpdateProject(Project project);
        public void DeleteProjectPhysically(int id);
        public void DeleteProjectLogically(int id);
        public IEnumerable<Project> SearchProjects(string name);
        public IEnumerable<string> GetProjectsFirstLetters();
    }
}
