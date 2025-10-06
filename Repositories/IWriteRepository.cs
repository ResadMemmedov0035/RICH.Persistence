using RICH.Persistence.Entities;

namespace RICH.Persistence.Repositories;

public interface IWriteRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TId : struct
{
    #region Async
    Task CreateAsync(TEntity entity, bool saveChanges = true);
    Task CreateAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
    Task<bool> DeleteAsync(TId id, bool saveChanges = true);
    Task DeleteAsync(TEntity entity, bool saveChanges = true);
    Task DeleteAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
    Task SaveChangesAsync();
    #endregion

    #region Sync
    void Create(TEntity entity, bool saveChanges = true);
    void Create(IEnumerable<TEntity> entities, bool saveChanges = true);
    bool Delete(TId id, bool saveChanges = true);
    void Delete(TEntity entity, bool saveChanges = true);
    void Delete(IEnumerable<TEntity> entities, bool saveChanges = true);
    void SaveChanges();
    #endregion
}
