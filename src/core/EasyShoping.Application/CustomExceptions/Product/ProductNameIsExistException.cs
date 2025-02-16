using EasyShoping.Application.CustomExceptions.Common;
using Microsoft.AspNetCore.Http;

namespace EasyShoping.Application.CustomExceptions.Product;

public class ProductNameIsExistException:CommonException
{
    public int StatusCode { get; set; }
    public ProductNameIsExistException()
    {
        
    }
    public ProductNameIsExistException(string message) : base(message) { }
    public ProductNameIsExistException(int statusCode, string message) : base(statusCode,message)
    {
        StatusCode = statusCode;
    }
}
