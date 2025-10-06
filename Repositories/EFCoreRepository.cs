using Microsoft.EntityFrameworkCore;

namespace RICH.Persistence.Repositories;

public abstract class EFCoreRepository(DbContext context)
{
    protected DbContext Context { get; } = context;
}
