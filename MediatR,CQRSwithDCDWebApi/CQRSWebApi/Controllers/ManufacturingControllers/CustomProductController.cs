using Domins.Models;
using Handler.Dto;
using Handler.MediatorHandler.MediatorCommand.CustomProducts;
using Handler.MediatorHandler.MediatorQuery.CustomProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWebApi.Controllers.ManfacturingControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("GetById{id}")]
        public async ValueTask<CustomProduct> GetByIdAsync(int id)
        {
            var custom = new GetCustomProductByIdQuery(id);
            return await _mediator.Send(custom);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public async ValueTask<IEnumerable<CustomProduct>> GetAllAsync()
        {
            var custom = new GetAllCustomProductsQuery();
            return await _mediator.Send(custom);
        }
        //[Authorize(Roles = "User")]
        [HttpPost("Add")]

        public async ValueTask<CustomProduct> AddAsync(CustomProductDto customProductDto)
        {
            var custom = new AddCustomProductCommand(customProductDto);
            return await _mediator.Send(custom);
        }
        //[Authorize(Roles = "User")]
        [HttpPut("Update{id}")]

        public async ValueTask<CustomProduct> UpdateAsync(CustomProductDto customProductDto)
        {
            var custom = new UpdateCustomProductCommand(customProductDto);
            return await _mediator.Send(custom);

        }
        //[Authorize(Roles = "User")]
        [HttpDelete("Delete{id}")]

        public async ValueTask<CustomProduct> DeleteAsync(int id)
        {
            var custom = new DeleteCustomProductCommand(id);
            return await _mediator.Send(custom);
        }

    }

}
