using AutoMapper;
using Domins.Models;
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
    public class DeleteValidatorHandler : IRequestHandler<DeleteCartCommand, Cart>
    {
        private readonly IUnityOfWork _unityOfWork;
        public DeleteValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<Cart> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var found = _unityOfWork.Carts.GetByidAsync(request.Id);
            return await _unityOfWork.Carts.DeleteAsync(request.Id);
        }
    }
}
