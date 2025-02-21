using EasyShoping.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EasyShoping.Application.Interfaces.Tokens;

public interface ITokenService
{
    Task<JwtSecurityToken> CreateToken(AppUser appUser, IList<string> roles);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
}
