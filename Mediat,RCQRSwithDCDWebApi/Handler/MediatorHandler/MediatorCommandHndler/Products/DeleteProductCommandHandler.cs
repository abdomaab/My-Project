using Domins.Models;
using Handler.MediatorHandler.MediatorCommand.Products;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommandHndler.Products
{
    public class DeleteProductValidatorHandler : IRequestHandler<DeleteProductrCommand, Product>
    {
        private readonly IUnityOfWork _unityOfWork;
        public DeleteProductValidatorHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<Product> Handle(DeleteProductrCommand request, CancellationToken cancellationToken)
        {
            var find = _unityOfWork.Products.GetByidAsync(request.Id);
            return await _unityOfWork.Products.DeleteAsync(request.Id);
        }
    }
}
