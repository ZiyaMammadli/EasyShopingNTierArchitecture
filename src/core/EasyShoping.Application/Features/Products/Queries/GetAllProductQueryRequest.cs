using MediatR;

namespace EasyShoping.Application.Features.Products.Queries;

public class GetAllProductQueryRequest:IRequest<List<GetAllProductQueryResponse>>
{
}
