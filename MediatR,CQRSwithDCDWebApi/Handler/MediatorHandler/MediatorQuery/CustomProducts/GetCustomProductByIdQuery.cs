using Domins.Models;
using MediatR;


namespace Handler.MediatorHandler.MediatorQuery.CustomProducts
{
    public class GetCustomProductByIdQuery : IRequest<CustomProduct>
    {
        public int Id { get; set; }
        public GetCustomProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
