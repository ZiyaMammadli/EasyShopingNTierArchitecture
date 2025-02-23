using EasyShoping.Application.Features.Auth.Rules;
using EasyShoping.Application.Interfaces.Tokens;
using EasyShoping.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EasyShoping.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
    private readonly ITokenService _tokenService;
    private readonly AuthRule _authRule;
    private readonly UserManager<AppUser> _userManager;

    public RefreshTokenCommandHandler(ITokenService tokenService, AuthRule authRule, UserManager<AppUser> userManager)
    {
        _tokenService = tokenService;
        _authRule = authRule;
        _userManager = userManager;
    }
    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        await _authRule.EnsurePrincipalExpiredTokenNotFound(principal);

        string? email = principal.FindFirstValue(ClaimTypes.Email);

        AppUser? appUser=await _userManager.FindByEmailAsync(email);
        await _authRule.EnsureRefreshTokenExpiredTime(appUser.RefreshTokenExpireTime);

        IList<string> roles =await _userManager.GetRolesAsync(appUser);
        JwtSecurityToken token= await _tokenService.CreateToken(appUser, roles);

        string refreshToken= _tokenService.GenerateRefreshToken();
        appUser.RefreshToken = refreshToken;

        await _userManager.UpdateAsync(appUser);

        RefreshTokenCommandResponse commandResponse = new()
        {
            AccessToken= new JwtSecurityTokenHandler().WriteToken(token),
            RefreshToken = refreshToken,
        };
        return commandResponse; 
    }
}
