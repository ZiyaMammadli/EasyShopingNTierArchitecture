namespace EasyShoping.Application.Features.Products.Queries;

public class GetAllProductQueryResponse
{
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double SalePrice { get; set; }
    public string BrandName { get; set; }
    public string CategoryName { get; set; }
    
}
