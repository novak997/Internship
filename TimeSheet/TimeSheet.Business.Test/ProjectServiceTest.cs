using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Business.Exceptions;
using TimeSheet.Business.Services;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using Xunit;

namespace TimeSheet.Business.Test
{
    public class ProjectServiceTest
    {
        [Fact]
        public void AddProjectTestNameEmpty()
        {
            Project project = new Project
            {
                Name = "",
                Description = "some description",
                ClientID = 1,
                LeadID = 1
            };
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var projectService = new ProjectService(projectRepositoryMock.Object);
            var exception = Assert.Throws<BusinessLayerException>(() => projectService.AddProject(project));
            Assert.Equal("Project name cannot be empty", exception.Message);
        }

        [Fact]
        public void AddProjectTestNameAndClientTaken()
        {
            Project project = new Project
            {
                Name = "some name",
                Description = "some description",
                ClientID = 1,
                LeadID = 1
            };
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(repo => repo.GetProjectByNameAndClient(It.IsAny<string>(), It.IsAny<int>())).Returns(project);
            var projectService = new ProjectService(projectRepositoryMock.Object);
            Project newProject = new Project
            {
                Name = "some name",
                Description = "some other description",
                ClientID = 1,
                LeadID = 2
            };
            var exception = Assert.Throws<BusinessLayerException>(() => projectService.AddProject(newProject));
            Assert.Equal("That client already has a project named like that", exception.Message);
        }

        [Fact]
        public void AddProjectTestSuccessful()
        {
            Project project = new Project
            {
                Name = "some name",
                Description = "some description",
                ClientID = 1,
                LeadID = 1
            };
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var projectService = new ProjectService(projectRepositoryMock.Object);
            var result = projectService.AddProject(project);
            Assert.Equal("Project successfully added", result);

        }
    }
}
