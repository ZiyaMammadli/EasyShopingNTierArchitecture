using EasyShoping.Application.CustomExceptions.Base;

namespace EasyShoping.Application.CustomExceptions.Product;

public class ProductNameIsExistException:BaseException
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
