using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.ViewModels;

namespace TavssStudent.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> GetProjectById(string projectId);
        Task<IEnumerable<Project>> GetProjectByName(string projectName);
        Task<Framework> GetFramework(string projectId);
        Task<List<Developer>> GetDevelopersInProject(string projectId);
        Task<Developer> GetDeveloperById(string developerId, string projectId);
        Task<string> GetWiki(string projectId);
        Task<string> DownloadProject(string projectId);
        Task<List<ToDo>> GetAllToDo(string projectId);
        Task<List<InProgress>> GetAllInProgress(string projectId);
        Task<List<Done>> GetAllDone(string projectId);

        //create
        Task<bool> CreateProject(CreateProjectViewModel model);
        Task<bool> CreateFramework(string projectId);
        Task<bool> AddDeveloperToProject(string projectId, Developer developer);
    }
}
