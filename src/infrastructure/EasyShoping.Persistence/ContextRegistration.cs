using EasyShoping.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShoping.Persistence;

public static class ContextRegistration
{
    public static void AddContextRegistration(this IServiceCollection services,IConfiguration config)
    {
        services.AddDbContext<EasyShopingDbContext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("default"));
        });
    }

}
