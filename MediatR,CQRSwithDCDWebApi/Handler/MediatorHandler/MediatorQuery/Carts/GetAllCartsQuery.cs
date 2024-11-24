using Domins.Models;
using MediatR;

namespace Handler.MediatorHandler.MediatorQuery.Carts
{
    public class GetAllCartsQuery : IRequest<IEnumerable<Cart>>
    {
    }
}
