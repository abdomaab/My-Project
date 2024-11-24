using Domins.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommand.Products
{
    public class DeleteProductrCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public DeleteProductrCommand(int id)
        {
            Id = id;
        }
    }
}
