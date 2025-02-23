using EasyShoping.Application.Features.Auth.Rules;
using EasyShoping.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EasyShoping.Application.Features.Auth.Commands.RevokeAll;

public class RevokeAllCommandHandler : IRequestHandler<RevokeAllCommandRequest, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AuthRule _authRule;

    public RevokeAllCommandHandler(UserManager<AppUser> userManager,AuthRule authRule)
    {
        _userManager = userManager;
        _authRule = authRule;
    }
    public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
    {
        List<AppUser> users= _userManager.Users.ToList();
        await _authRule.EnsureUsersNotFound(users);
        foreach (AppUser user in users)
        {
            user.RefreshToken = "null";
            await _userManager.UpdateAsync(user);
        }
        return Unit.Value;
    }
}
