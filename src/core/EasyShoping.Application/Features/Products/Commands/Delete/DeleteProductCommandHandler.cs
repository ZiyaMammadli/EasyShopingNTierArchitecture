using EasyShoping.Application.CustomExceptions.Product;
using EasyShoping.Application.Features.Products.Rules;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;
using MediatR;

namespace EasyShoping.Application.Features.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ProductRules _productRules;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork,ProductRules productRules)
    {
        _unitOfWork = unitOfWork;
        _productRules = productRules;
    }
    public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRules.EnsureForDeletedProductExistAsync(request.Id);

        product.IsDeleted=true;
        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await _unitOfWork.SaveAsync();
    }
}
