using EasyShoping.Application.CustomExceptions.Base;

namespace EasyShoping.Application.CustomExceptions.Auth;

public class InvalidUserPasswordException:BaseException
{
    public InvalidUserPasswordException() { }
    public InvalidUserPasswordException(string message) : base(message) { }
    public InvalidUserPasswordException(int StatusCode, string message) : base(StatusCode, message) { }
}
