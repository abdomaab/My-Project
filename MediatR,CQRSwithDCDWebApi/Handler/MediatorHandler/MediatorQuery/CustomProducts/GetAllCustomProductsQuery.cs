using Domins.Models;
using MediatR;


namespace Handler.MediatorHandler.MediatorQuery.CustomProducts
{
    public class GetAllCustomProductsQuery : IRequest<IEnumerable<CustomProduct>>
    {
    }
}
