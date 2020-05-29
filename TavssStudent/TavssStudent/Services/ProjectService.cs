using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.ViewModels;

namespace TavssStudent.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient httpClient;

        public ProjectService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task AddDeveloperToProject(string projectId, Developer developer)
        {
            await httpClient.PutJsonAsync<Developer>($"api/v1/project/{projectId}", developer);

        }

        public async Task<bool> AssignDone(string projectId, DoneViewModel model)
        {
           var result= await httpClient.PutJsonAsync<DoneViewModel>($"api/MongoProject/api/v1/project/AssignDone/{projectId}", model);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AssignInProgress(string projectId, InProgressViewModel model)
        {
            var result = await httpClient.PutJsonAsync<InProgressViewModel>($"api/MongoProject/api/v1/project/AssignInProgress/{projectId}", model);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AssignToDo(string projectId, ToDoViewModel model)
        {
            var result = await httpClient.PutJsonAsync<ToDoViewModel>($"api/MongoProject/api/v1/project/AssignToDo/{projectId}", model);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task CreateFramework(string projectId)
        {
            await httpClient.PostJsonAsync($"api/MongoProject/api/v1/project/CreateFramework/{projectId}", null);


        }

        public async Task CreateProject(CreateProjectViewModel model)
        {
            //var r = await httpClient.PostJsonAsync<CreateProjectViewModel>($"api/MongoProject/api/v1/project/CreateProject",model);

            StringContent modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/MongoProject/api/v1/project/CreateProject", modelJson);
            if (response.IsSuccessStatusCode)
            {
                var result = await JsonSerializer.DeserializeAsync<CreateProjectViewModel>(await response.Content.ReadAsStreamAsync());
                return;
            }
        }

        public async Task<string> DownloadProject(string projectId)
        {
            return await httpClient.GetJsonAsync<String>($"api/MongoProject/api/v1/project/DownloadProject/{projectId}");

        }

        public async Task<List<Done>> GetAllDone(string projectId)
        {
            return await httpClient.GetJsonAsync<List<Done>>($"api/v1/project/{projectId}");

        }

        public async Task<List<InProgress>> GetAllInProgress(string projectId)
        {
            return await httpClient.GetJsonAsync<List<InProgress>>($"api/v1/project/{projectId}");

        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await httpClient.GetJsonAsync<List<Project>>($"api/MongoProject/api/v1/project/GetAllProjects");

            //return await JsonSerializer.DeserializeAsync<IEnumerable<Project>>
            //(await httpClient.GetStreamAsync($"api/mongoproject/api/v1/project/getallprojects"),
            //    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<List<ToDo>> GetAllToDo(string projectId)
        {
            return await httpClient.GetJsonAsync<List<ToDo>>($"api/MongoProject/api/v1/project/GetProjectById/{projectId}");

        }

        public async Task<Developer> GetDeveloperById(string developerId, string projectId)
        {
            return await httpClient.GetJsonAsync<Developer>($"api/v1/project/{developerId}/{projectId}");

        }

        public async Task<List<Developer>> GetDevelopersInProject(string projectId)
        {
            return await httpClient.GetJsonAsync<List<Developer>>($"api/v1/project/{projectId}");

        }

        public async Task<Framework> GetFramework(string projectId)
        {
            var r= await httpClient.GetJsonAsync<Framework>($"api/MongoProject/api/v1/project/GetFramework/{projectId}");
            return r;
        }

        public async Task<Project> GetProjectById(string projectId)
        {
            //var r= await httpClient.GetJsonAsync<Project>($"api/MongoProject/api/v1/project/GetProjectById/{projectId}");
            //return r;
            return await JsonSerializer.DeserializeAsync<Project>
            (await httpClient.GetStreamAsync($"api/MongoProject/api/v1/project/GetProjectById/{projectId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Project>> GetProjectByName(string projectName)
        {
            return await httpClient.GetJsonAsync<IEnumerable<Project>>($"api/v1/project/{projectName}");

        }

        public async Task<string> GetWiki(string projectId)
        {
            return await httpClient.GetJsonAsync<string>($"api/v1/project/{projectId}");

        }
    }
}
