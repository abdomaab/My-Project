using Domins.Models;
using Handler.MediatorHandler.MediatorQuery.CustomProducts;
using Handler.UnityOfWork;
using MediatR;


namespace Handler.MediatorHandler.MediatorQueryHandler.CustomProducts
{
    public class GetCustomProductByIdQueryHandler : IRequestHandler<GetCustomProductByIdQuery, CustomProduct>
    {
        private readonly IUnityOfWork _unityOfWork;
        public GetCustomProductByIdQueryHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<CustomProduct> Handle(GetCustomProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unityOfWork.CustomProducts.GetByidAsync(request.Id);
        }
    }
}
