using AutoMapper;
using Domins.Models;
using Handler.Dto;
using Handler.MediatorHandler.MediatorCommand.Carts;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommandHndler.Carts
{
    public class UpdateCartValidatorHandler : IRequestHandler<UpdateCartCommand, Cart>
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public UpdateCartValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<Cart> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var find = _unityOfWork.Carts.GetByidAsync(request.Id);
            var cart = _mapper.Map<Cart>(request);
            return await _unityOfWork.Carts.UpdateAsync(cart);
        }
    }
}
