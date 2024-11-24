using AutoMapper;
using Domins.Models;
using Handler.Dto;
using Handler.Extensions;
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
    public class UpdateProductValidatorHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public UpdateProductValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var find = _unityOfWork.Products.GetByidAsync(request.Id);
            var product = _mapper.Map<Product>(request);
            await ImageHandler.ImageConverterAsync(request.Image1);
            await ImageHandler.ImageConverterAsync(request.Image2);
            await ImageHandler.ImageConverterAsync(request.Image3);
            return await _unityOfWork.Products.UpdateAsync(product);
        }
    }
}
