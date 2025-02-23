using FluentValidation;

namespace EasyShoping.Application.Features.Auth.Commands.Login;

public class LoginCommandValidator:AbstractValidator<LoginCommandRequest>
{
    public LoginCommandValidator()
    {
        RuleFor(l=>l.Email)
            .NotEmpty().WithMessage("Email can not be null")
            .NotEmpty().WithMessage("Email can not be empty");
        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("Email can not be null")
            .NotEmpty().WithMessage("Password can not be empty");
    }
}
