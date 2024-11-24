using Domins.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommand.Orders
{
    public class DeleteOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
        public DeleteOrderCommand(int id )
        {
            Id = id;
        }
    }
}
