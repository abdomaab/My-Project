using AutoMapper;
using Domins.Models;
using Handler.Dto;
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
    public class UpdateOrderValidatorHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public UpdateOrderValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var find = _unityOfWork.CustomProducts.GetByidAsync(request.Id);
            var order = _mapper.Map<Order>(request);
            return await _unityOfWork.Orders.UpdateAsync(order);
        }
    }
}
