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
    public class AddOrderValidatorHandler : IRequestHandler<AddOrderCommand, Order>
    {

        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public AddOrderValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<Order> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            return await _unityOfWork.Orders.AddAsync(order);
        }
    }
}
