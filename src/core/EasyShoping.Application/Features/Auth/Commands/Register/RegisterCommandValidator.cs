using FluentValidation;

namespace EasyShoping.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty().WithMessage("FirstName can not be empty");
        RuleFor(r => r.LastName)
          .NotEmpty().WithMessage("LastName can not be empty");
        RuleFor(r => r.UserName)
            .NotEmpty().WithMessage("Username can not be empty");
        RuleFor(r=>r.Email)
            .NotEmpty().WithMessage("Email can not be empty")
            .EmailAddress();
        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("Password can not be empty");        
        RuleFor(r => r.ConfirmPassword)
            .NotEmpty().WithMessage("ConfirmPassword can not be empty")
            .Equal(r=>r.Password).WithMessage("ConfirmPassword must be equal with password");
    }
}
