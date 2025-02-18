using FluentValidation;

namespace EasyShoping.Application.Features.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id can not being empty")
            .GreaterThan(0).WithMessage("Id must be high from 0");
        RuleFor(p => p.BrandId)
            .NotEmpty().WithMessage("BrandId can not being empty")
            .GreaterThan(0).WithMessage("BrandId must be high from 0");
        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("CategoryId can not being empty")
            .GreaterThan(0).WithMessage("CategoryId must be high from 0");
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name can not being empty");
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Description can not being empty");
        RuleFor(p => p.CostPrice)
            .NotEmpty().WithMessage("CostPrice can not being empty")
            .GreaterThan(0).WithMessage("CostPrice must be high from 0");
        RuleFor(p => p.SalePrice)
            .NotEmpty().WithMessage("SalePrice can not being empty")
            .GreaterThan(0).WithMessage("SalePrice must be high from 0");
        RuleFor(p => p.IsDeleted)
            .NotEmpty().WithMessage("IsDeleted can not being empty");

    }
}
