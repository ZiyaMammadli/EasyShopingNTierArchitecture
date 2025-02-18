using EasyShoping.Application.Behaviours;
using EasyShoping.Application.ExceptionMiddleware;
using EasyShoping.Application.Features.Products.Commands.Create;
using EasyShoping.Application.Features.Products.Queries.GetAll;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShoping.Application;

public static class ApplicationRegister
{
    public static void AddApplicationRegister(this IServiceCollection services)
    {
        services.AddMediatR(confg=>confg.RegisterServicesFromAssembly(typeof(GetAllProductQueryRequest).Assembly));
        services.AddTransient<ExceptionHandlerMiddleware>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        services.AddValidatorsFromAssemblyContaining(typeof(CreateProductCommandValidator));
    }
}
