using AutoMapper;
using Domins.Models;
using Handler.Dto;
using Handler.MediatorHandler.MediatorCommand.Carts;
using Handler.UnityOfWork;
using MediatR;


namespace Handler.MediatorHandler.MediatorCommandHndler.Carts
{
    public class AddCartValidatorHandler : IRequestHandler<AddCartCommand, Cart>
    {

        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public AddCartValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<Cart> Handle(AddCartCommand request, CancellationToken cancellationToken)
        {
            var cart = _mapper.Map<Cart>(request);
            return await _unityOfWork.Carts.AddAsync(cart);
            
        }
    }
}
