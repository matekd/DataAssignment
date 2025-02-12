using Business.Models;

namespace Business.Interfaces;

public interface IProjectService
{
    public Task<bool> CreateProjectAsync(ProjectRegistrationForm form);
    public Task<IEnumerable<Project>> GetProjectsAsync();
    public Task<Project?> GetProjectByIdAsync(int id);
    public Task<bool> UpdateProjectAsync(ProjectUpdateForm form);
    public Task<bool> DeleteProjectAsync(int id);
}
