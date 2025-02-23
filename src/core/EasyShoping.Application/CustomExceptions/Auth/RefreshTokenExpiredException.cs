using EasyShoping.Application.CustomExceptions.Base;

namespace EasyShoping.Application.CustomExceptions.Auth;

public class RefreshTokenExpiredException:BaseException
{
    public RefreshTokenExpiredException() { }
    public RefreshTokenExpiredException(string message) : base(message) { }
    public RefreshTokenExpiredException(int StatusCode, string message) : base(StatusCode, message) { }
}
