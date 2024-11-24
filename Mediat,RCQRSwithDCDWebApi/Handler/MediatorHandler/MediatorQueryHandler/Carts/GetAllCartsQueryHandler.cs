using Domins.Models;
using Handler.MediatorHandler.MediatorQuery.Carts;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorQueryHandler.Carts
{
    public class GetAllCartsQueryHandler : IRequestHandler<GetAllCartsQuery, IEnumerable<Cart>>
    {
        private readonly IUnityOfWork _unityOfWork;

        public GetAllCartsQueryHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<IEnumerable<Cart>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            return await _unityOfWork.Carts.GetAllAsync();

        }
    }
}
