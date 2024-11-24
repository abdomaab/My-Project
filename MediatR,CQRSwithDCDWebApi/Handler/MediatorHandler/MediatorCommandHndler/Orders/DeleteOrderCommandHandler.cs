using AutoMapper;
using Domins.Models;
using Handler.MediatorHandler.MediatorCommand.Orders;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommandHndler.Orders
{
    public class DeleteOrderValidatorHandler : IRequestHandler<DeleteOrderCommand, Order>
    {
        private readonly IUnityOfWork _unityOfWork;
        public DeleteOrderValidatorHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<Order> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var find = _unityOfWork.Orders.GetByidAsync(request.Id);
            return await _unityOfWork.Orders.DeleteAsync(request.Id);
        }
    }
}
