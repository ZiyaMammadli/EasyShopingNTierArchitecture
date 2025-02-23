using FluentValidation;

namespace EasyShoping.Application.Features.Auth.Commands.Revoke;

public class RevokeCommandValidator:AbstractValidator<RevokeCommandRequest>
{
    public RevokeCommandValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Email can not be empty")
            .EmailAddress().WithMessage("This area must be email");
    }
}
