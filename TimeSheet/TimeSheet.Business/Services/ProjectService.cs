using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Exceptions;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public string AddProject(Project project)
        {
            try
            {
                if (project.Name == "" || project.Name == null || project.Status == "" || project.Status == null)
                {
                    throw new BusinessLayerException("Project name and status cannot be empty");
                }
                if (_projectRepository.GetProjectByNameAndClient(project.Name, project.ClientID).Name != null)
                {
                    throw new BusinessLayerException("That client already has a project named like that");
                }
                _projectRepository.AddProject(project);
                return "Project successfully added";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public IEnumerable<Project> GetAllProjects()
        {
            try
            {
                return _projectRepository.GetAllProjects();
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public Project GetProjectById(int id)
        {
            try
            {
                return _projectRepository.GetProjectById(id);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public string UpdateProject(Project project)
        {
            try
            {
                if (project.Name == "" || project.Name == null || project.Status == "" || project.Status == null)
                {
                    throw new BusinessLayerException("Project name and status cannot be empty");
                }
                if (_projectRepository.GetProjectByNameAndClient(project.Name, project.ClientID).Name != null)
                {
                    throw new BusinessLayerException("That client already has a project named like that");
                }
                _projectRepository.UpdateProject(project);
                return "Project successfully updated";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public string DeleteProjectLogically(int id)
        {
            try
            {
                _projectRepository.DeleteProjectLogically(id);
                return "Project successfully deleted";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public IEnumerable<Project> SearchProjects(string name)
        {
            try
            {
                return _projectRepository.SearchProjects(name);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public IEnumerable<string> GetProjectsFirstLetters()
        {
            try
            {
                return _projectRepository.GetProjectsFirstLetters();
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
    }
}
