using EasyShoping.Application.ExceptionMiddleware;
using EasyShoping.Application.Features.Products.Queries.GetAll;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShoping.Application;

public static class ApplicationRegister
{
    public static void AddApplicationRegister(this IServiceCollection services)
    {
        services.AddMediatR(confg=>confg.RegisterServicesFromAssembly(typeof(GetAllProductQueryRequest).Assembly));
        services.AddTransient<ExceptionHandlerMiddleware>();
    }
}
