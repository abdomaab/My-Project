using Domins.Models;
using Handler.Dto;
using Handler.MediatorHandler.MediatorCommand.Carts;
using Handler.MediatorHandler.MediatorQuery.Carts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWebApi.Controllers.ManfacturingControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("GetById{id}")]
        public async ValueTask<Cart> GetByIdAsync(int id)
        {
            var query = new GetCartByIdQuery(id);
            return await _mediator.Send(query);
        }
        [HttpGet("GetAll")]
        public async ValueTask<IEnumerable<Cart>> GetAllAsync()
        {
            var query = new GetAllCartsQuery();
            return await _mediator.Send(query);

        }
        //[Authorize(Roles = "User")]
        [HttpPost("Add")]

        public async ValueTask<Cart> AddAsync(CartDto cartDto)
        {
            var cart = new AddCartCommand(cartDto);
            return await _mediator.Send(cart);
            
            
        }
        //[Authorize(Roles = "User")]
        [HttpPut("Update{id}")]

        public async ValueTask<Cart> UpdateAsync(CartDto cartDto)
        {
            var cart = new UpdateCartCommand(cartDto);
            return await _mediator.Send(cart);
        }
        //[Authorize(Roles = "User")]
        [HttpDelete("Delete{id}")]

        public async ValueTask<Cart> DeleteAsync(int id)
        {
            var cart = new DeleteCartCommand(id);
            return await _mediator.Send(cart);
        }
    }
}
