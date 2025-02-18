using EasyShoping.Application.CustomExceptions.Base;

namespace EasyShoping.Application.CustomExceptions.Category;

public class CategoryNotFoundException:BaseException
{
    public int StatusCode { get; set; }

    public CategoryNotFoundException()
    {
        
    }
    public CategoryNotFoundException(string message):base(message) { }
    public CategoryNotFoundException(int statusCode, string message) : base(statusCode,message)
    {
        StatusCode = statusCode;
    }
}
