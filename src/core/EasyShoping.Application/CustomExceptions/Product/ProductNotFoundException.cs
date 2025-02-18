using EasyShoping.Application.CustomExceptions.Base;

namespace EasyShoping.Application.CustomExceptions.Product;

public class ProductNotFoundException:BaseException
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
