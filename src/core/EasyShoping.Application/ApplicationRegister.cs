using EasyShoping.Application.Features.Products.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShoping.Application;

public static class ApplicationRegister
{
    public static void AddApplicationRegister(this IServiceCollection services)
    {
        services.AddMediatR(confg=>confg.RegisterServicesFromAssembly(typeof(GetAllProductQueryRequest).Assembly));  
    }
}
