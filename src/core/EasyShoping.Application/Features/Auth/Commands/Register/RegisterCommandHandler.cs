using EasyShoping.Application.Features.Auth.Rules;
using EasyShoping.Application.Interfaces.AutoMapper;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EasyShoping.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
{
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly RegisterRule _registerRule;
    private readonly RoleManager<Role> _roleManager;

    public RegisterCommandHandler(IMapper mapper, 
        UserManager<AppUser> userManager, 
        RegisterRule registerRule,
        RoleManager<Role> roleManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _registerRule = registerRule;
        _roleManager = roleManager;
    }
    public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        await _registerRule.EnsureUserExistAsync(await _userManager.FindByEmailAsync(request.Email));

        var user = _mapper.Map<AppUser, RegisterCommandRequest>(request);
        user.RefreshToken = "token";
        user.IsDeleted = false;

        user.EmailConfirmed = false;
        user.PhoneNumberConfirmed = false;
        user.LockoutEnabled = false;
        user.TwoFactorEnabled = false;
        user.AccessFailedCount = 0;

        var result = await _userManager.CreateAsync(user,request.Password);
        if (result.Succeeded)
        {
            if(! await _roleManager.RoleExistsAsync("member"))
            {
                Role role = new()
                {
                    Id =Guid.NewGuid(),
                    Name="member",
                    NormalizedName="MEMBER",
                    ConcurrencyStamp=Guid.NewGuid().ToString(),
                };
                await _roleManager.CreateAsync(role);   
            }
                await _userManager.AddToRoleAsync(user, "member");
        }
        return Unit.Value;
    }
}
