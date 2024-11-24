using Domins.Models;
using Handler.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommand.Orders
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int Contact { get; set; }
        public int CartId { get; set; }

        public UpdateOrderCommand(OrderDto orderDto)
        {
            Id = orderDto.Id;
            Name = orderDto.Name;
            Address = orderDto.Address;
            City = orderDto.City;
            State = orderDto.State;
            ZipCode = orderDto.ZipCode;
            Contact = orderDto.Contact;
            CartId = orderDto.CartId;
        }
    }
}
