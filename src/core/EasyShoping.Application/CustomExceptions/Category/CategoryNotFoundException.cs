using EasyShoping.Application.CustomExceptions.Common;

namespace EasyShoping.Application.CustomExceptions.Category;

public class CategoryNotFoundException:CommonException
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
