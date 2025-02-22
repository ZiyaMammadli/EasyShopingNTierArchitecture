using EasyShoping.Application.Bases;
using EasyShoping.Application.CustomExceptions.Auth;
using EasyShoping.Domain.Entities;
using System.Globalization;

namespace EasyShoping.Application.Features.Auth.Rules;

public class RegisterRule:BaseRules
{
    public Task EnsureUserExistAsync(AppUser appUser)
    {
        if(appUser is not null) throw new UserAlreadyExistException(400,"User is already exist");
        return Task.CompletedTask;
    }
}
