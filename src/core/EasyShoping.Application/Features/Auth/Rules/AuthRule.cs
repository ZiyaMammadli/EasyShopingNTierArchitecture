using EasyShoping.Application.Bases;
using EasyShoping.Application.CustomExceptions.Auth;
using EasyShoping.Domain.Entities;
using System.Security.Claims;

namespace EasyShoping.Application.Features.Auth.Rules;

public class AuthRule:BaseRules
{
    public Task EnsureUserNotFound(AppUser user)
    {
        if (user is null) throw new UserNotFoundException(404, "User is not found");
        return Task.CompletedTask;
    }
    public Task EnsureUserPasswordCheck(bool isPasswordCheck)
    {
        if (!isPasswordCheck) throw new InvalidUserPasswordException(400, "Email or Password is incorrect");
        return Task.CompletedTask;
    }
    public Task EnsureUserExistAsync(AppUser appUser)
    {
        if (appUser is not null) throw new UserAlreadyExistException(400, "User is already exist");
        return Task.CompletedTask;
    }
    public Task EnsurePrincipalExpiredTokenNotFound(ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal is null) throw new PrincipalExpiredTokenNotFoundException(404, "PrincipalExpiredToken is not found");
        return Task.CompletedTask;
    }
    public Task EnsureRefreshTokenExpiredTime(DateTime? expiredTime)
    {
        if (expiredTime <= DateTime.UtcNow) throw new RefreshTokenExpiredException(400, "RefreshToken has expired");
        return Task.CompletedTask;
    }
}
