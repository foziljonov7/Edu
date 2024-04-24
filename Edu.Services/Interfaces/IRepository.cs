using System.Linq.Expressions;

namespace Edu.Services.Interfaces;

public interface IRepository<TEntity>
{
    Task<bool> SaveAsync(CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<TEntity> CreatedAsync(TEntity newEntity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdatedAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null, CancellationToken cancellationToken = default);
    Task<IQueryable<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> expression = null, string[] includes = null, CancellationToken cancellationToken = default);
}
