using Microsoft.Extensions.DependencyInjection;
using RICH.Persistence.Repositories;

namespace RICH.Persistence.DependencyInjection;

public static class ServiceRegistration
{
    public static void AddRICHPersistence(this IServiceCollection services)
    {
        services.AddScoped(typeof(IWriteRepository<,>), typeof(EFCoreWriteRepository<,>));
        services.AddScoped(typeof(IReadRepository<,>), typeof(EFCoreReadRepository<,>));
    }
}
