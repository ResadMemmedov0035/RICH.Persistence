using Microsoft.EntityFrameworkCore;
using RICH.Persistence.Entities;

namespace RICH.Persistence.Repositories;

public class EFCoreWriteRepository<TEntity, TId>(DbContext context) : EFCoreRepository(context), IWriteRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TId : struct
{
    #region Async
    public async Task CreateAsync(TEntity entity, bool saveChanges = true)
    {
        await Context.AddAsync(entity);
        if (saveChanges)
            await Context.SaveChangesAsync();
    }

    public async Task CreateAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        await Context.AddRangeAsync(entities);
        if (saveChanges)
            await Context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(TId id, bool saveChanges = true)
    {
        TEntity? entity = await Context.FindAsync<TEntity>(id);
        if (entity is null) return false;
        await DeleteAsync(entity, saveChanges);
        return true;
    }

    public async Task DeleteAsync(TEntity entity, bool saveChanges = true)
    {
        Context.Remove(entity);
        if (saveChanges)
            await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        Context.RemoveRange(entities);
        if (saveChanges)
            await Context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
        => await Context.SaveChangesAsync();
    #endregion

    #region Sync
    public void Create(TEntity entity, bool saveChanges = true)
    {
        Context.Add(entity);
        if (saveChanges) SaveChanges();
    }

    public void Create(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        Context.AddRange(entities);
        if (saveChanges) SaveChanges();
    }

    public bool Delete(TId id, bool saveChanges = true)
    {
        TEntity? entity = Context.Find<TEntity>(id);
        if (entity is null) return false;
        Delete(entity, saveChanges);
        return true;
    }

    public void Delete(TEntity entity, bool saveChanges = true)
    {
        Context.Remove(entity);
        SaveChanges();
    }

    public void Delete(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        Context.RemoveRange(entities);
        SaveChanges();
    }

    public void SaveChanges() => Context.SaveChanges();
    #endregion
}