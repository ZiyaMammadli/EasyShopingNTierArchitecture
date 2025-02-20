using EasyShoping.Application.Repositories;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;
using EasyShoping.Persistence.Contexts;
using EasyShoping.Persistence.Repositories;
using EasyShoping.Persistence.UnitOfWorks;
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
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddIdentityCore<AppUser>(opt =>
        {
            opt.Password.RequiredLength = 8;
            opt.Password.RequireNonAlphanumeric = true;
            opt.Password.RequireDigit = true;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.User.RequireUniqueEmail = true;
            opt.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789._";
        })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<EasyShopingDbContext>();
    }

}
