using EasyShoping.Application.CustomExceptions.Brand;
using EasyShoping.Application.CustomExceptions.Category;
using EasyShoping.Application.CustomExceptions.Product;
using EasyShoping.Application.Interfaces.AutoMapper;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;
using MediatR;

namespace EasyShoping.Application.Features.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (request is null) throw new NullReferenceException();
        var category = await _unitOfWork.GetReadRepository<Category>().GetSingleAsync(c => c.Id == request.CategoryId);
        if (category is null) throw new CategoryNotFoundException("Category is not found");
        var brand = await _unitOfWork.GetReadRepository<Brand>().GetSingleAsync(b=>b.Id == request.BrandId);
        if (brand is null) throw new BrandNotFoundException("Brand is not found");
        var product=await _unitOfWork.GetReadRepository<Product>().GetSingleAsync(p=>p.Name==request.Name);
        if (product is not null) throw new ProductNameIsExistException("Product name already is exist");

        var productt = _mapper.Map<Product, CreateProductCommandRequest>(request);
        await _unitOfWork.GetWriteRepository<Product>().AddAsync(productt);
        await _unitOfWork.SaveAsync();
        CreateProductCommandResponse response = new();
        return response;
    }
}
