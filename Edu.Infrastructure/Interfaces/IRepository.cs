using System.Linq.Expressions;

namespace Edu.Infrastructure.Interfaces;

public interface IRepository<TEntity>
{
    Task<bool> SaveAsync();
    Task<bool> DeleteAsync(int id);
    Task<TEntity> CreatedAsync(TEntity newEntity);
    TEntity UpdatedAsync(TEntity entity);
    Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);
    IQueryable<TEntity> SelectAllAsync(Expression<Func<TEntity, bool>> expression = null, string[] includes = null);
}
