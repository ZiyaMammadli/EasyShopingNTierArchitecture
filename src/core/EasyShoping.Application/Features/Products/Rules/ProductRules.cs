using EasyShoping.Application.Bases;
using EasyShoping.Application.CustomExceptions.Brand;
using EasyShoping.Application.CustomExceptions.Category;
using EasyShoping.Application.CustomExceptions.Product;
using EasyShoping.Application.UnitOfWorks;
using EasyShoping.Domain.Entities;

namespace EasyShoping.Application.Features.Products.Rules;

public class ProductRules:BaseRules
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task EnsureProductNameExistAsync(string productName)
    {
        if (await _unitOfWork.GetReadRepository<Product>().GetSingleAsync(p=>p.Name== productName) !=null) 
            throw new ProductNameIsExistException(400,"Product name already is exist");
    }
    public async Task EnsureCategoryExistAsync(int categoryId)
    {
        if(await _unitOfWork.GetReadRepository<Category>().GetSingleAsync(c=>c.Id==categoryId) == null)
            throw new CategoryNotFoundException(404,"Category is not found");
    }
    public async Task EnsureBrandExistAsync(int brandId)
    {
        if(await _unitOfWork.GetReadRepository<Brand>().GetSingleAsync(b=>b.Id==brandId) == null)
            throw new BrandNotFoundException(404,"Brand is not found");
    }
    public async Task<Product> EnsureForDeletedProductExistAsync(int productId)
    {
        var product = await _unitOfWork.GetReadRepository<Product>().GetSingleAsync(p => p.Id == productId && p.IsDeleted == false);
        if (product == null)
            throw new BrandNotFoundException(404, "Product is not found");
        return product;
    }
    public async Task EnsureProductExistAsync(int productId)
    {
        if (await _unitOfWork.GetReadRepository<Product>().GetSingleAsync(p => p.Id == productId) == null)
            throw new BrandNotFoundException(404, "Product is not found");
    }
}
