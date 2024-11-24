using Domins.Models;
using Handler.MediatorHandler.MediatorQuery.Orders;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorQueryHandler.Orders
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IUnityOfWork _unityOfWork;
        public GetOrderByIdQueryHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unityOfWork.Orders.GetByidAsync(request.Id);
        }
    }
}
