using Domins.Models;
using Handler.Dto;
using MediatR;

namespace Handler.MediatorHandler.MediatorCommand.Carts
{
    public class AddCartCommand : IRequest<Cart>
    {
        public int Id { get; set; }
        public string Custom { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public AddCartCommand(CartDto cartDto)
        {
            Id = cartDto.Id;
            Custom = cartDto.Custom;
            Size = cartDto.Size;
            Quantity = cartDto.Quantity;
            ProductId = cartDto.ProductId;
            OrderId = cartDto.OrderId;
        }
    }
}
