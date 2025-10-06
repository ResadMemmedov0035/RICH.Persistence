using Microsoft.EntityFrameworkCore;
using RICH.Persistence.Criterias;
using RICH.Persistence.Entities;
using System.Linq.Expressions;

namespace RICH.Persistence.Repositories;

public class EFCoreReadRepository<TId, TEntity>(DbContext context) : EFCoreRepository(context), IReadRepository<TId, TEntity>
    where TId : struct
    where TEntity : Entity<TId>, new()
{
    protected IQueryable<TEntity> Query(bool tracking)
    {
        DbSet<TEntity> set = Context.Set<TEntity>();
        return tracking ? set : set.AsNoTracking();
    }

    #region Async
    public async Task<TEntity?> GetAsync(TId id, bool tracking = true)
        => await GetAsync(x => x.Id.Equals(id), tracking);

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> condition, bool tracking = true)
        => await Query(tracking)
        .FirstOrDefaultAsync(condition);

    public async Task<TEntity?> GetAsync(Criteria<TEntity> criteria, bool tracking = true) 
        => await criteria.Evaluate(Query(tracking))
        .FirstOrDefaultAsync();


    public async Task<TDestination?> GetAsync<TDestination>(TId id, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => await GetAsync(x => x.Id.Equals(id), projecter, tracking);

    public async Task<TDestination?> GetAsync<TDestination>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => await Query(tracking)
        .Where(condition)
        .Select(projecter)
        .FirstOrDefaultAsync();

    public async Task<TDestination?> GetAsync<TDestination>(Criteria<TEntity> criteria, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => await criteria.Evaluate(Query(tracking))
        .Select(projecter)
        .FirstOrDefaultAsync();


    public async Task<List<TEntity>> GetListAsync(bool tracking = true)
        => await Query(tracking)
        .ToListAsync();

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> condition, bool tracking = true)
        => await Query(tracking)
        .Where(condition)
        .ToListAsync();

    public async Task<List<TEntity>> GetListAsync(Criteria<TEntity> criteria, bool tracking = true)
        => await criteria.Evaluate(Query(tracking))
        .ToListAsync();


    public async Task<List<TDestination>> GetListAsync<TDestination>(Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => await Query(tracking)
        .Select(projecter)
        .ToListAsync();

    public async Task<List<TDestination>> GetListAsync<TDestination>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => await Query(tracking)
        .Where(condition)
        .Select(projecter)
        .ToListAsync();

    public async Task<List<TDestination>> GetListAsync<TDestination>(Criteria<TEntity> criteria, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => await criteria.Evaluate(Query(tracking))
        .Select(projecter)
        .ToListAsync();

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? condition = null)
        => condition is null
            ? Context.Set<TEntity>().AnyAsync()
            : Context.Set<TEntity>().AnyAsync(condition);

    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? condition = null)
        => condition is null
            ? Context.Set<TEntity>().CountAsync()
            : Context.Set<TEntity>().CountAsync(condition);
    #endregion

    #region Sync
    public TEntity? Get(TId id, bool tracking = true)
        => Get(x => x.Id.Equals(id), tracking);

    public TEntity? Get(Expression<Func<TEntity, bool>> condition, bool tracking = true)
        => Query(tracking)
        .FirstOrDefault(condition);

    public TEntity? Get(Criteria<TEntity> criteria, bool tracking = true)
        => criteria.Evaluate(Query(tracking))
        .FirstOrDefault();


    public TDestination? Get<TDestination>(TId id, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => Get(x => x.Id.Equals(id), projecter, tracking);

    public TDestination? Get<TDestination>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => Query(tracking)
        .Where(condition)
        .Select(projecter)
        .FirstOrDefault();

    public TDestination? Get<TDestination>(Criteria<TEntity> criteria, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => criteria.Evaluate(Query(tracking))
        .Select(projecter)
        .FirstOrDefault();


    public List<TEntity> GetList(bool tracking = true)
        => [.. Query(tracking)];

    public List<TEntity> GetList(Expression<Func<TEntity, bool>> condition, bool tracking = true)
        => [.. Query(tracking).Where(condition)];

    public List<TEntity> GetList(Criteria<TEntity> criteria, bool tracking = true)
        => criteria.Evaluate(Query(tracking))
        .ToList();


    public List<TDestination> GetList<TDestination>(Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => [.. Query(tracking).Select(projecter)];

    public List<TDestination> GetList<TDestination>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => [.. Query(tracking).Where(condition).Select(projecter)];

    public List<TDestination> GetList<TDestination>(Criteria<TEntity> criteria, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true)
        => criteria.Evaluate(Query(tracking))
        .Select(projecter)
        .ToList();


    public bool Any(Expression<Func<TEntity, bool>>? condition = null)
        => condition is null
        ? Context.Set<TEntity>().Any()
        : Context.Set<TEntity>().Any(condition);

    public int Count(Expression<Func<TEntity, bool>>? condition = null)
        => condition is null 
        ? Context.Set<TEntity>().Count() 
        : Context.Set<TEntity>().Count(condition);
    #endregion
}