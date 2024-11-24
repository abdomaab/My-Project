using AutoMapper;
using Domins.Models;
using Handler.Dto;
using Handler.Extensions;
using Handler.MediatorHandler.MediatorCommand.Products;
using Handler.UnityOfWork;
using MediatR;

namespace Handler.MediatorHandler.MediatorCommandHndler.Products
{
    public class AddProductValidatorHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public AddProductValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await ImageHandler.ImageConverterAsync(request.Image1);
            await ImageHandler.ImageConverterAsync(request.Image2);
            await ImageHandler.ImageConverterAsync(request.Image3);
            return await _unityOfWork.Products.AddAsync(product);
        }
    }
}
