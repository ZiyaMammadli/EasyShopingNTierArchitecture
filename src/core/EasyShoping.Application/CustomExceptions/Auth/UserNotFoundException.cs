using EasyShoping.Application.CustomExceptions.Base;

namespace EasyShoping.Application.CustomExceptions.Auth;

public class UserNotFoundException:BaseException
{
    public UserNotFoundException() { }
    public UserNotFoundException(string message):base(message) { }
    public UserNotFoundException(int StatusCode,string message):base(StatusCode,message) { }
}
