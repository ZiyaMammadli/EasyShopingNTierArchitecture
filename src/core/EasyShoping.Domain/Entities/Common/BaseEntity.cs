namespace EasyShoping.Domain.Entities.Common;

public class BaseEntity:IBaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDated { get; set; }
    public DateTime UpdatedDated { get; set;}

}
