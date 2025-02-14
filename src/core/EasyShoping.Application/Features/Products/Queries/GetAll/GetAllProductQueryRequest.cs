using MediatR;

namespace EasyShoping.Application.Features.Products.Queries.GetAll;

public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
{
}
