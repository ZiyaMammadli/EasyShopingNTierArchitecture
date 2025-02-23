using EasyShoping.Application.Bases;
using EasyShoping.Application.CustomExceptions.Auth;
using EasyShoping.Domain.Entities;

namespace EasyShoping.Application.Features.Auth.Rules;

public class LoginRule:BaseRules
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
}
