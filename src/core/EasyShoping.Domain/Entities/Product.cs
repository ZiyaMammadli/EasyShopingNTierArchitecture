using EasyShoping.Domain.Entities.Common;

namespace EasyShoping.Domain.Entities;

public class Product:BaseEntity
{
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double SalePrice { get; set; }
    public double CostPrice { get; set; }
    public Category Category { get; set; }
    public Brand Brand { get; set; }
    public List<UserProduct> userProducts { get; set; }

}
