using EasyShoping.Application.CustomExceptions.Base;

namespace EasyShoping.Application.CustomExceptions.Auth;

public class PrincipalExpiredTokenNotFoundException:BaseException
{
    public PrincipalExpiredTokenNotFoundException() { }
    public PrincipalExpiredTokenNotFoundException(string message) : base(message) { }
    public PrincipalExpiredTokenNotFoundException(int StatusCode, string message) : base(StatusCode, message) { }
}
