using EasyShoping.Application.Features.Auth.Rules;
using EasyShoping.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EasyShoping.Application.Features.Auth.Commands.Revoke;

public class RevokeCommandHandler : IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AuthRule _authRule;

    public RevokeCommandHandler(UserManager<AppUser> userManager,AuthRule authRule)
    {
        _userManager = userManager;
        _authRule = authRule;
    }
    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? user=await _userManager.FindByEmailAsync(request.Email);
        await _authRule.EnsureUserNotFound(user);
        user.RefreshToken = "null";
        await _userManager.UpdateAsync(user);
        return Unit.Value;
    }
}
