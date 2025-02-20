using EasyShoping.Application.CustomExceptions.Brand;
using EasyShoping.Application.CustomExceptions.Category;
using EasyShoping.Application.CustomExceptions.Product;
using EasyShoping.Application.Features.Products.Rules;
using EasyShoping.Application.Interfaces.AutoMapper;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;
using MediatR;

namespace EasyShoping.Application.Features.Products.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ProductRules _productRules;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,ProductRules productRules)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _productRules = productRules;
    }
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var products=await _unitOfWork.GetReadRepository<Product>().GetAllAsync();
        if (request is null) throw new NullReferenceException();

        await _productRules.EnsureCategoryExistAsync(request.CategoryId);

        await _productRules.EnsureBrandExistAsync(request.BrandId);

        await _productRules.EnsureProductNameExistAsync(request.Name);

        var productt = _mapper.Map<Product, CreateProductCommandRequest>(request);
        productt.UpdatedDated=DateTime.UtcNow;
        productt.CreatedDated=DateTime.UtcNow;

        await _unitOfWork.GetWriteRepository<Product>().AddAsync(productt);
        await _unitOfWork.SaveAsync();
        CreateProductCommandResponse response = new();
        return response;
    }
}
