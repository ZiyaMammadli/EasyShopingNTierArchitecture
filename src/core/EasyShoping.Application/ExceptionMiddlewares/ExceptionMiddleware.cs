using EasyShoping.Application.ExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace EasyShoping.Application.ExceptionMiddlewares;

public static class ExceptionMiddleware
{
    public static void UseExceptionHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
