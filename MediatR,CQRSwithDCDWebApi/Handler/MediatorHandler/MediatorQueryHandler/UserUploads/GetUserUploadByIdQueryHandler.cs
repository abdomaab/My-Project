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
    public class GetUserUploadByIdQueryHandler : IRequestHandler<GetUserUploadByIdQuery, UserUpload>
    {
        private readonly IUnityOfWork _unityOfWork;
        public GetUserUploadByIdQueryHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<UserUpload> Handle(GetUserUploadByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unityOfWork.UserUploads.GetByidAsync(request.Id);
        }
    }
}
