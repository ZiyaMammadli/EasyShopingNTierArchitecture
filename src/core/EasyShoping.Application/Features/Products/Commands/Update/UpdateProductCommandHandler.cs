using EasyShoping.Application.CustomExceptions.Brand;
using EasyShoping.Application.CustomExceptions.Category;
using EasyShoping.Application.CustomExceptions.Product;
using EasyShoping.Application.Interfaces.AutoMapper;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;
using MediatR;

namespace EasyShoping.Application.Features.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var productt=await _unitOfWork.GetReadRepository<Product>().GetSingleAsync(p=>p.Id==request.Id);
        if (productt is null) throw new ProductNotFoundException(404,"Product is not found");
        var category = await _unitOfWork.GetReadRepository<Category>().GetSingleAsync(p => p.Id == request.CategoryId);
        if (category is null) throw new CategoryNotFoundException(404,"Category is not found"); 
        var brand = await _unitOfWork.GetReadRepository<Brand>().GetSingleAsync(b=>b.Id == request.BrandId);
        if (brand is null) throw new BrandNotFoundException(404, "Brand is not found");
        if (request.CostPrice > request.SalePrice) throw new Exception("Cost Price can not be higher than Sale Price");


        Product product = _mapper.Map<Product, UpdateProductCommandRequest>(request);
        product.UpdatedDated=DateTime.UtcNow;

        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await _unitOfWork.SaveAsync();
        return new UpdateProductCommandResponse();  
    }
}
