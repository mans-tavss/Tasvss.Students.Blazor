using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.ViewModels;

namespace TavssStudent.Services
{
    public class ProjectService : IProjectService
    {
        public Task<bool> AddDeveloperToProject(string projectId, Developer developer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateFramework(string projectId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateProject(CreateProjectViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<string> DownloadProject(string projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Done>> GetAllDone(string projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<InProgress>> GetAllInProgress(string projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDo>> GetAllToDo(string projectId)
        {
            throw new NotImplementedException();
        }

        public Task<Developer> GetDeveloperById(string developerId, string projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Developer>> GetDevelopersInProject(string projectId)
        {
            throw new NotImplementedException();
        }

        public Task<Framework> GetFramework(string projectId)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectById(string projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjectByName(string projectName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetWiki(string projectId)
        {
            throw new NotImplementedException();
        }
    }
}
