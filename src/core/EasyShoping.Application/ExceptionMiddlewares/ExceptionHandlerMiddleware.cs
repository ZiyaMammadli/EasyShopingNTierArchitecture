using EasyShoping.Application.CustomExceptions.Common;
using EasyShoping.Application.CustomExceptions.Product;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EasyShoping.Application.ExceptionMiddleware;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (CommonException ex)
		{
			//int statusCode = GetStatusCode(ex);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = ex.StatusCode;	
			ExceptionModel exceptionModel = new()
			{
				Message = ex.Message,
				StatusCode= context.Response.StatusCode,
			};
			string json =JsonSerializer.Serialize(exceptionModel);
			await context.Response.WriteAsync(json);
		}
    }
	//private static int GetStatusCode(Exception exception) =>
	//	exception switch
	//	{
	//		BadRequestException=>StatusCodes.Status400BadRequest,
	//		NotFoundException=>StatusCodes.Status400BadRequest,
	//		ValidationException=>StatusCodes.Status422UnprocessableEntity,
	//		_=>StatusCodes.Status500InternalServerError,
	//	};
}
