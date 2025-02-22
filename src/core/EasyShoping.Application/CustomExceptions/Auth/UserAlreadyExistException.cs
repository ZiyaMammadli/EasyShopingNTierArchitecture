using EasyShoping.Application.CustomExceptions.Base;

namespace EasyShoping.Application.CustomExceptions.Auth;

public class UserAlreadyExistException:BaseException
{
    public UserAlreadyExistException() { }
    public UserAlreadyExistException(string message) : base(message) { }
    public UserAlreadyExistException(int StatusCode,string message) : base(StatusCode, message) { }
}
