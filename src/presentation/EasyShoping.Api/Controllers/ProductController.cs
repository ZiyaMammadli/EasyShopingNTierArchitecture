using EasyShoping.Application.CustomExceptions.Brand;
using EasyShoping.Application.CustomExceptions.Category;
using EasyShoping.Application.CustomExceptions.Product;
using EasyShoping.Application.Features.Products.Commands.Create;
using EasyShoping.Application.Features.Products.Commands.Delete;
using EasyShoping.Application.Features.Products.Commands.Update;
using EasyShoping.Application.Features.Products.Queries;
using EasyShoping.Application.Features.Products.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyShoping.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {

            var product = await _mediator.Send(request);
            return Ok();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {

            var product = await _mediator.Send(request);
            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {

            await _mediator.Send(request);
            return Ok();

        }
    }
}
