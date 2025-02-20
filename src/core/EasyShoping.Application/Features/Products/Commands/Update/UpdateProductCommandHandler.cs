using EasyShoping.Application.CustomExceptions.Brand;
using EasyShoping.Application.CustomExceptions.Category;
using EasyShoping.Application.CustomExceptions.Product;
using EasyShoping.Application.Features.Products.Rules;
using EasyShoping.Application.Interfaces.AutoMapper;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;
using MediatR;

namespace EasyShoping.Application.Features.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ProductRules _productRules;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,ProductRules productRules)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _productRules = productRules;
    }
    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productRules.EnsureProductExistAsync(request.Id);
        
        await _productRules.EnsureCategoryExistAsync(request.CategoryId);

        await _productRules.EnsureBrandExistAsync(request.BrandId);

        Product product = _mapper.Map<Product, UpdateProductCommandRequest>(request);
        product.UpdatedDated=DateTime.UtcNow;

        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await _unitOfWork.SaveAsync();
        return new UpdateProductCommandResponse();  
    }
}
