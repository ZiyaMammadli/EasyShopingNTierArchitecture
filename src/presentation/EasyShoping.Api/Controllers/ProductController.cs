using EasyShoping.Application.CustomExceptions.Brand;
using EasyShoping.Application.CustomExceptions.Category;
using EasyShoping.Application.CustomExceptions.Product;
using EasyShoping.Application.Features.Products.Commands;
using EasyShoping.Application.Features.Products.Queries;
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
            var products =await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            try
            {
                var product = await _mediator.Send(request);
                return Ok();
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            catch (CategoryNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BrandNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProductNameIsExistException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
