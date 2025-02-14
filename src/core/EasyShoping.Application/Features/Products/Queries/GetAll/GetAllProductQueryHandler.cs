using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EasyShoping.Application.Features.Products.Queries.GetAll;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        List<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include: query => query.Include(p => p.Category).Include(p => p.Brand));

        List<GetAllProductQueryResponse> getAllProductQueryResponses = products.Select(p => new GetAllProductQueryResponse
        {
            Name = p.Name,
            Description = p.Description,
            SalePrice = p.SalePrice,
            CategoryId = p.CategoryId,
            BrandId = p.BrandId,
            BrandName = p.Brand.Name,
            CategoryName = p.Category.Name,
            IsDeleted = p.IsDeleted,
        }).ToList();

        return getAllProductQueryResponses;
    }
}
