using Microsoft.Extensions.Logging;
using RICH.Persistence.Criterias;
using RICH.Persistence.Entities;
using System.Linq.Expressions;

namespace RICH.Persistence.Repositories;

public interface IReadRepository<TId, TEntity>
    where TId : struct
    where TEntity : Entity<TId>, new()
{
    #region Async
    public Task<TEntity?> GetAsync(TId id, bool tracking = true);
    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> condition, bool tracking = true);
    public Task<TEntity?> GetAsync(Criteria<TEntity> criteria, bool tracking = true);

    public Task<TDestination?> GetAsync<TDestination>(TId id, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);
    public Task<TDestination?> GetAsync<TDestination>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);
    public Task<TDestination?> GetAsync<TDestination>(Criteria<TEntity> criteria, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);

    public Task<List<TEntity>> GetListAsync(bool tracking = true);
    public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> condition, bool tracking = true);
    public Task<List<TEntity>> GetListAsync(Criteria<TEntity> criteria, bool tracking = true);

    public Task<List<TDestination>> GetListAsync<TDestination>(Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);
    public Task<List<TDestination>> GetListAsync<TDestination>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);
    public Task<List<TDestination>> GetListAsync<TDestination>(Criteria<TEntity> criteria, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? condition = null);
    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? condition = null);
    #endregion

    #region Sync
    public TEntity? Get(TId id, bool tracking = true);
    public TEntity? Get(Expression<Func<TEntity, bool>> condition, bool tracking = true);
    public TEntity? Get(Criteria<TEntity> criteria, bool tracking = true);

    public TDestination? Get<TDestination>(TId id, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);
    public TDestination? Get<TDestination>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);
    public TDestination? Get<TDestination>(Criteria<TEntity> criteria, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);

    public List<TEntity> GetList(bool tracking = true);
    public List<TEntity> GetList(Expression<Func<TEntity, bool>> condition, bool tracking = true);
    public List<TEntity> GetList(Criteria<TEntity> criteria, bool tracking = true);

    public List<TDestination> GetList<TDestination>(Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);
    public List<TDestination> GetList<TDestination>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);
    public List<TDestination> GetList<TDestination>(Criteria<TEntity> criteria, Expression<Func<TEntity, TDestination>> projecter, bool tracking = true);

    public bool Any(Expression<Func<TEntity, bool>>? condition = null);
    public int Count(Expression<Func<TEntity, bool>>? condition = null);
    #endregion
}
