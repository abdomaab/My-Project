using Domins.Models;
using Handler.MediatorHandler.MediatorQuery.Categories;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorQueryHandler.Categories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly IUnityOfWork _unityOfWork;

        public GetAllCategoriesQueryHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _unityOfWork.Categories.GetAllAsync();
        }
    }
}
