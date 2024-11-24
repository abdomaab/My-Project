using Domins.Models;
using Handler.MediatorHandler.MediatorQuery.CustomProducts;
using Handler.UnityOfWork;
using MediatR;


namespace Handler.MediatorHandler.MediatorQueryHandler.CustomProducts
{
    public class GetAllCustomProductsQueryHandler : IRequestHandler<GetAllCustomProductsQuery, IEnumerable<CustomProduct>>
    {
        private readonly IUnityOfWork _unityOfWork;
        public GetAllCustomProductsQueryHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<IEnumerable<CustomProduct>> Handle(GetAllCustomProductsQuery request, CancellationToken cancellationToken)
        {
            return await _unityOfWork.CustomProducts.GetAllAsync();
        }
    }
}
