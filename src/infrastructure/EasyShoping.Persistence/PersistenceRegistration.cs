using EasyShoping.Domain.Repositories;
using EasyShoping.Persistence.Contexts;
using EasyShoping.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShoping.Persistence;

public static class PersistenceRegistration
{
    public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<EasyShopingDbContext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("default"));
        });
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
    }

}
