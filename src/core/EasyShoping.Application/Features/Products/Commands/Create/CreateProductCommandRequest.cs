using MediatR;

namespace EasyShoping.Application.Features.Products.Commands.Create;

public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public double SalePrice { get; set; }
    public double CostPrice { get; set; }
}
