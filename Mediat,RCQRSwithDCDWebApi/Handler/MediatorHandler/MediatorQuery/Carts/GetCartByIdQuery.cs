using Domins.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorQuery.Carts
{
    public class GetCartByIdQuery : IRequest<Cart>
    {
        public int Id { get; set; }

        public GetCartByIdQuery(int id)
        {
            Id = id;
        }
    }
}
