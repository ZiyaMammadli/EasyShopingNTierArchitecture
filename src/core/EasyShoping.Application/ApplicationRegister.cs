using EasyShoping.Application.Bases;
using EasyShoping.Application.Behaviours;
using EasyShoping.Application.ExceptionMiddleware;
using EasyShoping.Application.Features.Products.Commands.Create;
using EasyShoping.Application.Features.Products.Queries.GetAll;
using EasyShoping.Application.Features.Products.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EasyShoping.Application;

public static class ApplicationRegister
{
    public static void AddApplicationRegister(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(confg=>confg.RegisterServicesFromAssembly(typeof(GetAllProductQueryRequest).Assembly));
        services.AddTransient<ExceptionHandlerMiddleware>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        services.AddValidatorsFromAssemblyContaining(typeof(CreateProductCommandValidator));
        services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
    }
    private static IServiceCollection AddRulesFromAssemblyContaining(
        this IServiceCollection services,
        Assembly assembly,
        Type type)
    {
        var types= assembly.GetTypes().Where(t=>t.IsSubclassOf(type) && type!=t).ToList();
        foreach(var item in types)
        {
            services.AddTransient(item);
        }
        return services;
    }
}
