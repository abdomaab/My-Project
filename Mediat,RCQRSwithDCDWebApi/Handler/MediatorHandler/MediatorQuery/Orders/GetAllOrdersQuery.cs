using Domins.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorQuery.Orders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
