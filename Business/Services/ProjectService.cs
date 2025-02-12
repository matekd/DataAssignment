using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    public readonly IProjectRepository _projectRepository = projectRepository;
    // other services

    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        if (form == null)
            return false;

        // Check if foreign keys exist, using services, or repos for .exists?
        // return false if any fails

        try
        {
            await _projectRepository.BeginTransactionAsync();

            await _projectRepository.CreateAsync(ProjectFactory.Create(form));
            await _projectRepository.SaveAsync();

            await _projectRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _projectRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        var entity = await _projectRepository.GetAsync(x => x.Id == id);

        if (entity == null)
            return null;

        return ProjectFactory.Create(entity);
    }

    public async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync();

        if (entities == null)
            return [];
        
        return entities.Select(ProjectFactory.Create!);
    }

    public async Task<bool> UpdateProjectAsync(ProjectUpdateForm form)
    {
        if (form == null)
            return false;

        try
        {
            await _projectRepository.BeginTransactionAsync();

            _projectRepository.Update(ProjectFactory.Create(form));
            await _projectRepository.SaveAsync();

            await _projectRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _projectRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
        try
        {
            var entity = await _projectRepository.GetAsync(x => x.Id == id);
            if (entity == null) 
                return false;

            await _projectRepository.BeginTransactionAsync();

            _projectRepository.Delete(entity);
            await _projectRepository.SaveAsync();

            await _projectRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _projectRepository.RollbackTransactionAsync();
            return false;
        }
    }
}
