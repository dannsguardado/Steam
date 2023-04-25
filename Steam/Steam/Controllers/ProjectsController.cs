using STEAM.Services;
using Microsoft.AspNetCore.Mvc;
using STEAM.Models.Project;

namespace STEAM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        public async Task<List<GetProjectDTO>> GetProjects()
        {
            return await _projectsService.GetProjects();
        }

        [HttpGet("{id}")]
        public async Task<GetProjectDTO?> GetProject(int id)
        {
            return await _projectsService.GetProject(id);
        }

        [HttpPost]
        public async Task PostProject(AddProjectDTO project)
        {
            await _projectsService.AddProject(project);
        }

        [HttpPut]
        public async Task PutProject(UpdateProjectDTO project)
        {
            await _projectsService.UpdateProject(project);
        }


        [HttpDelete("{id}")]
        public async Task DeleteProject(int id)
        {
            await _projectsService.DeleteProject(id);
        }

    }
}