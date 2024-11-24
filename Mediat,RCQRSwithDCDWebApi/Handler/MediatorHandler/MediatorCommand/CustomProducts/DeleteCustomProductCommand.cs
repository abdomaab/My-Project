using Domins.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommand.CustomProducts
{
    public class DeleteCustomProductCommand : IRequest<CustomProduct>
    {
        public int Id { get; set; }
        
        public DeleteCustomProductCommand(int id)
        {
            Id = id;
        }
    }
}
