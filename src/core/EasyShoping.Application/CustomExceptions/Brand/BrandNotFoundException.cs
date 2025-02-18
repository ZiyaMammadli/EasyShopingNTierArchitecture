using EasyShoping.Application.CustomExceptions.Base;

namespace EasyShoping.Application.CustomExceptions.Brand;

public class BrandNotFoundException:BaseException
{
    public int StatusCode { get; set; }
    public BrandNotFoundException()
    {
        
    }
    public BrandNotFoundException(string message) : base(message) { }
    public BrandNotFoundException(int statusCode, string message) : base(statusCode,message)
    {
        StatusCode = statusCode;
    }

}
