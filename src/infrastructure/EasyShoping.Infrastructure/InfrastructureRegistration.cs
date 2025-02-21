using EasyShoping.Infrastructure.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShoping.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureRegistration(IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<TokenSettings>(configuration.GetSection("JWT"));
    }
}
