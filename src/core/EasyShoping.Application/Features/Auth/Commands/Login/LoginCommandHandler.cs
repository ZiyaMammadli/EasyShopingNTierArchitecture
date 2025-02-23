using EasyShoping.Application.Features.Auth.Rules;
using EasyShoping.Application.Interfaces.Tokens;
using EasyShoping.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace EasyShoping.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly LoginRule _loginRule;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;

    public LoginCommandHandler(UserManager<AppUser> userManager,
        RoleManager<Role> roleManager,
        LoginRule loginRule,
        ITokenService tokenService,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _loginRule = loginRule;
        _tokenService = tokenService;
        _configuration = configuration;
    }
    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByEmailAsync(request.Email);
        await _loginRule.EnsureUserNotFound(user);
        var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        await _loginRule.EnsureUserPasswordCheck(checkPassword);
        IList<string> roles = await _userManager.GetRolesAsync(user);
        JwtSecurityToken token = await _tokenService.CreateToken(user, roles);
        string _token =new JwtSecurityTokenHandler().WriteToken(token);
        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
        string refreshToken = _tokenService.GenerateRefreshToken();
        user.RefreshToken=refreshToken;
        user.RefreshTokenExpireTime=DateTime.UtcNow.AddDays(refreshTokenValidityInDays);
        await _userManager.UpdateAsync(user);
        await _userManager.UpdateSecurityStampAsync(user);
        LoginCommandResponse response = new LoginCommandResponse()
        {
            Token=_token,
            RefreshToken=refreshToken,
            Expiration=token.ValidTo,
        };
        return response;
    }
}
