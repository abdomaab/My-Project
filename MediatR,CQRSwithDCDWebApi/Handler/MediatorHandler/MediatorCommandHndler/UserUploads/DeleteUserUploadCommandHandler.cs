using Domins.Models;
using Handler.MediatorHandler.MediatorCommand.UserUploads;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommandHndler.UserUploads
{
    public class DeleteUserUploadValidatorHandler : IRequestHandler<DeleteUserUploadCommand, UserUpload>
    {
        private readonly IUnityOfWork _unityOfWork;
        public DeleteUserUploadValidatorHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<UserUpload> Handle(DeleteUserUploadCommand request, CancellationToken cancellationToken)
        {
            var find = _unityOfWork.UserUploads.GetByidAsync(request.Id);
            return await _unityOfWork.UserUploads.DeleteAsync(request.Id);
        }
    }
}
