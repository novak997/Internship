using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using TimeSheet.Repositories;

namespace TimeSheet.Services
{
    public class ProjectService
    {
        private readonly ProjectRepository _projectRepository = new ProjectRepository();
        public string AddProject(Project project)
        {
            if (_projectRepository.GetProjectByNameAndClient(project.Name, project.ClientID).Name != null)
            {
                return "That client already has a project named like that";
            }
            _projectRepository.AddProject(project);
            return "Project successfully added";
        }
        public IEnumerable<Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }
        public Project GetProjectById(int id)
        {
            return _projectRepository.GetProjectById(id);
        }
        public string UpdateProject(Project project)
        {
            if (_projectRepository.GetProjectByNameAndClient(project.Name, project.ClientID).Name != null)
            {
                return "That client already has a project named like that";
            }
            _projectRepository.UpdateProject(project);
            return "Project successfully updated";
        }
        public void DeleteProjectLogically(int id)
        {
            _projectRepository.DeleteProjectLogically(id);
        }
        public IEnumerable<Project> SearchProjects(string name)
        {
            return _projectRepository.SearchProjects(name);
        }
        public IEnumerable<string> GetProjectsFirstLetters()
        {
            return _projectRepository.GetProjectsFirstLetters();
        }
    }
}
