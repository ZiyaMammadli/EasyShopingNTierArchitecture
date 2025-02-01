using EasyShoping.Domain.Entities.Common;

namespace EasyShoping.Domain.Entities;

public class Brand:BaseEntity
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}
