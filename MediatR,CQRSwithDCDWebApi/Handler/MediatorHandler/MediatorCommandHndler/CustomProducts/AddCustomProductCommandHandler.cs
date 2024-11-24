using AutoMapper;
using Domins.Models;
using Handler.Dto;
using Handler.Extensions;
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
    public class AddCustomProductValidatorHandler : IRequestHandler<AddCustomProductCommand, CustomProduct>
    {

        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public AddCustomProductValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<CustomProduct> Handle(AddCustomProductCommand request, CancellationToken cancellationToken)
        {
            var custom = _mapper.Map<CustomProduct>(request);
            await ImageHandler.ImageConverterAsync(request.Image);
            return await _unityOfWork.CustomProducts.AddAsync(custom);
        }
    }
}
