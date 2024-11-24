using Domins.Models;
using MediatR;


namespace Handler.MediatorHandler.MediatorQuery.Categories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
