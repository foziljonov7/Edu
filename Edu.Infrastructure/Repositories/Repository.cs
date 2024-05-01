using Edu.DAL.DbContexts;
using Edu.Domain.Helpers.Commons;
using Edu.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Edu.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext dbContext;

    DbSet<TEntity> dbSet;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<TEntity>();
    }
    public async Task<TEntity> CreatedAsync(TEntity newEntity, CancellationToken cancellationToken = default)
        => (await dbSet.AddAsync(newEntity).ConfigureAwait(false)).Entity;

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken).ConfigureAwait(false);
        dbSet.Remove(entity);
        return true;
    }

	public async Task<bool> ExistAsync(long id, CancellationToken cancellationToken = default)
	{
        return await dbSet.AnyAsync(d => d.Id == id, cancellationToken);
	}

	public async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
        => await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;

    public Task<IQueryable<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> expression = null, string[] includes = null, CancellationToken cancellationToken = default)
    {
        return Task.Run(() =>
            {
                var query = expression is null ? dbSet : dbSet.Where(expression);
                if (includes is not null)
                    foreach (var include in includes)
                        query = query.Include(include);

                return query;
            }, cancellationToken);
    }
    public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null, CancellationToken cancellationToken = default)
    {
        var query = await SelectAllAsync(expression, includes, cancellationToken).ConfigureAwait(false);
        return await query.FirstOrDefaultAsync(expression, cancellationToken).ConfigureAwait(false);
    }


    public Task<TEntity> UpdatedAsync(TEntity entity, CancellationToken cancellationToken = default)
        => Task.Run(() => dbSet.Update(entity).Entity, cancellationToken);
}