using Domins.Models;
using Handler.Dto;
using Handler.MediatorHandler.MediatorCommand.Orders;
using Handler.MediatorHandler.MediatorQuery.CustomProducts;
using Handler.MediatorHandler.MediatorQuery.Orders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWebApi.Controllers.ManfacturingControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("GetById{id}")]
        public async ValueTask<Order> GetByIdAsync(int id)
        {
            var order = new GetOrderByIdQuery(id);
            return await _mediator.Send(order);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public async ValueTask<IEnumerable<Order>> GetAllAsync()
        {
            var order = new GetAllOrdersQuery();
            return await _mediator.Send(order);
        }
        //[Authorize(Roles = "User")]
        [HttpPost("Add")]

        public async ValueTask<Order> AddAsync(OrderDto orderDto)
        {
            var order = new AddOrderCommand(orderDto);
            return await _mediator.Send(order);
        }
        //[Authorize(Roles = "User")]
        [HttpPut("Update{id}")]

        public async ValueTask<Order> UpdateAsync(OrderDto ordeDto)
        {
            var order = new UpdateOrderCommand(ordeDto);
            return await _mediator.Send(order);
        }

        [HttpDelete("Delete{id}")]

        public async ValueTask<Order> DeleteAsync(int id)
        {
            var order = new DeleteOrderCommand(id);
            return await _mediator.Send(order);
        }

    }
}
