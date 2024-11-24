using Domins.Models;
using Handler.MediatorHandler.MediatorCommand.CustomProducts;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommandHndler.CustomProducts
{
    public class DeleteCustomProductValidatorHandler : IRequestHandler<DeleteCustomProductCommand, CustomProduct>
    {
        private readonly IUnityOfWork _unityOfWork;
        public DeleteCustomProductValidatorHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<CustomProduct> Handle(DeleteCustomProductCommand request, CancellationToken cancellationToken)
        {
            var find = _unityOfWork.CustomProducts.GetByidAsync(request.Id);
            return await _unityOfWork.CustomProducts.DeleteAsync(request.Id);
        }
    }
}
