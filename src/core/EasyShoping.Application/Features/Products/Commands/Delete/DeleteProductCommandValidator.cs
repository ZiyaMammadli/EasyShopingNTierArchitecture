using FluentValidation;

namespace EasyShoping.Application.Features.Products.Commands.Delete;

public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id can not being empty")
            .GreaterThan(0).WithMessage("Id must be high from 0");
    }
}
