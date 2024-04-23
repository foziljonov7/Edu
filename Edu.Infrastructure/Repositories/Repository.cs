using Edu.DAL.DbContexts;
using Edu.Domain.Helpers.Commons;
using Edu.Domain.Models;
using Edu.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
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
    public async Task<TEntity> CreatedAsync(TEntity newEntity)
        => (await dbSet.AddAsync(newEntity)).Entity;

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await dbSet.FirstOrDefaultAsync(e => e.Id == id);
        dbSet.Remove(entity);
        return true;
    }

    public async Task<bool> SaveAsync()
        => await dbContext.SaveChangesAsync() > 0;

    public IQueryable<TEntity> SelectAllAsync(Expression<Func<TEntity, bool>> expression = null, string[] includes = null)
    {
        var query = expression is null ? dbSet : dbSet.Where(expression);
        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }

    public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        => await SelectAllAsync(expression, includes).FirstOrDefaultAsync();

    public TEntity UpdatedAsync(TEntity entity)
        => dbSet.Update(entity).Entity;
}
