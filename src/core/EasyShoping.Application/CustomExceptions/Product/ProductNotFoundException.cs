using EasyShoping.Application.CustomExceptions.Common;
using Microsoft.AspNetCore.Http;

namespace EasyShoping.Application.CustomExceptions.Product;

public class ProductNotFoundException:CommonException
{
    public int StatusCode { get; set; }
    public ProductNotFoundException()
    {
        
    }
    public ProductNotFoundException(string message):base(message) { }
    public ProductNotFoundException(int statusCode, string message) : base(statusCode,message)
    {
        StatusCode = statusCode;
    }
}
