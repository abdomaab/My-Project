using Domins.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommand.Carts
{
    public class DeleteCartCommand : IRequest<Cart>
    {
        public int Id { get; set; }
        public DeleteCartCommand(int id)
        {
            Id = id;
        }
    }
}
