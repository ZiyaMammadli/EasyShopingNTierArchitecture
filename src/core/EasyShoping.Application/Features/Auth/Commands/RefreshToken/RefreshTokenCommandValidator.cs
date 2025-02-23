using FluentValidation;

namespace EasyShoping.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandValidator:AbstractValidator<RefreshTokenCommandRequest>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty().WithMessage("RefreshToken can not be empty");
        RuleFor(x => x.AccessToken)
            .NotEmpty().WithMessage("AccessToken can not be empty");
    }
}
