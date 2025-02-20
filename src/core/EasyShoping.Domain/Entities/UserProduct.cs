using EasyShoping.Domain.Entities.Common;

namespace EasyShoping.Domain.Entities;

public class UserProduct:BaseEntity
{
    public Guid UserId { get; set; }
    public int ProductId { get; set; }
    public AppUser User { get; set; }
    public Product Product { get; set; }
}
