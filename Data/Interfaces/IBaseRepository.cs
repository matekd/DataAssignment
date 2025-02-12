using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task RollbackTransactionAsync();
    Task CommitTransactionAsync();
    Task BeginTransactionAsync();

    Task CreateAsync(TEntity entity);
    Task<IEnumerable<TEntity?>> GetAllAsync();
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<bool> AlreadyExists(Expression<Func<TEntity, bool>> expression);
    Task<int> SaveAsync();
}