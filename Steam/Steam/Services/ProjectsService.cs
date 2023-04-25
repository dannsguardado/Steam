using AutoMapper;
using STEAM.Database;
using STEAM.Database.Entities;
using STEAM.Models.Project;
using Microsoft.EntityFrameworkCore;

namespace STEAM.Services
{
    public interface IProjectsService   
    {
        Task<List<GetProjectDTO>> GetProjects();
        Task<GetProjectDTO?> GetProject(int id);
        Task AddProject(AddProjectDTO experience);
        Task UpdateProject(UpdateProjectDTO project);
        Task DeleteProject(int id);
    }

    public class ProjectsService : IProjectsService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public ProjectsService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GetProjectDTO>> GetProjects()
        {
            var result = await _dbContext.Projects
                .ToListAsync();

            return result.Select(x => _mapper.Map<GetProjectDTO>(x)).ToList();
        }

        public async Task<GetProjectDTO?> GetProject(int id)
        {
            var result = await _dbContext.Projects
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<GetProjectDTO>(result);
        }

        public async Task AddProject(AddProjectDTO project)
        {
            var entity = _mapper.Map<Project>(project);
            await _dbContext.Projects.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProject(UpdateProjectDTO project)
        {
            var entity = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == project.Id);

            if(entity == null)
            {
                return;
            }
            _mapper.Map(project, entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var entity = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return;
            }

            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
