using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<IEnumerable<ProjectEntity?>> GetAllAsync()
    {
        var entities = await _dbSet
            .Include(project => project.Service)
            .Include(project => project.Customer)
            .Include(project => project.Employee)
            .Include(project => project.Status)
            .ToListAsync();

        return entities;
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        if (expression == null)
            return null;

        var entity = await _dbSet
            .Include(project => project.Service)
            .Include(project => project.Customer)
            .Include(project => project.Employee)
            .Include(project => project.Status)
            .FirstOrDefaultAsync(expression);

        return entity ?? null!;
    }
}
