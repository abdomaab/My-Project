using Domins.Models;
using Handler.MediatorHandler.MediatorQuery.Carts;
using Handler.UnityOfWork;
using MediatR;


namespace Handler.MediatorHandler.MediatorQueryHandler.Carts
{
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Cart>
    {
        private readonly IUnityOfWork _unityOfWork;

        public GetCartByIdQueryHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unityOfWork.Carts.GetByidAsync(request.Id);
        }
    }
}
