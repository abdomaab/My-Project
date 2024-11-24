using Domins.Models;
using Handler.Dto;
using Handler.MediatorHandler.MediatorCommand.Products;
using Handler.MediatorHandler.MediatorQuery.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWebApi.Controllers.ManfacturingControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetById{id}")]
        public async ValueTask<Product> GetByIdAsync(int id)
        {
            var order = new GetProductByIdQuery(id);
            return await _mediator.Send(order);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IEnumerable<Product>> GetAllAsync()
        {
            var order = new GetAllProductsQuery();
            return await _mediator.Send(order);
        }
       
        [HttpPost("Add")]
        public async ValueTask<Product> AddAsync(ProductDto productDto)
        {
            var order = new AddProductCommand(productDto);
            return await _mediator.Send(order);
        }
        [HttpPut("Update{id}")]

        public async ValueTask<Product> UpdateAsync(ProductDto productDto)
        {
            var order = new UpdateProductCommand(productDto);
            return await _mediator.Send(order);
        }
        [HttpDelete("Delete{id}")]

        public async ValueTask<Product> DeleteAsync(int id, ProductDto orderDto)
        {
            var order = new DeleteProductrCommand(id);
            return await _mediator.Send(order);
        }
    }
}
