using EasyShoping.Application.CustomExceptions.Product;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;
using MediatR;

namespace EasyShoping.Application.Features.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product=await _unitOfWork.GetReadRepository<Product>().GetSingleAsync(p=>p.Id==request.Id && p.IsDeleted==false);
        if (product is null) throw new ProductNotFoundException(404,"Product is not found");

        product.IsDeleted=true;
        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await _unitOfWork.SaveAsync();
    }
}
