namespace EasyShoping.Application.CustomExceptions.Common;

public class CommonException:Exception
{
    public int StatusCode { get; set; }
    public CommonException()
    {

    }
    public CommonException(string message) : base(message) { }
    public CommonException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}
