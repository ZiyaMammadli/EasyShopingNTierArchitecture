using MediatR;

namespace EasyShoping.Application.Features.Products.Commands.Update;

public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse>
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public double SalePrice { get; set; }
    public double CostPrice { get; set; }
    public bool IsDeleted { get; set; }
}
