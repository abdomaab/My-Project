using Domins.Models;
using Handler.MediatorHandler.MediatorQuery.UserUploads;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorQueryHandler.UserUploads
{
    public class GetAllUserUploadsQueryHandler : IRequestHandler<GetAllUserUploadsQuery, IEnumerable<UserUpload>>
    {
        private readonly IUnityOfWork _unityOfWork;
        public GetAllUserUploadsQueryHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<IEnumerable<UserUpload>> Handle(GetAllUserUploadsQuery request, CancellationToken cancellationToken)
        {
            return await _unityOfWork.UserUploads.GetAllAsync();
        }
    }
}
