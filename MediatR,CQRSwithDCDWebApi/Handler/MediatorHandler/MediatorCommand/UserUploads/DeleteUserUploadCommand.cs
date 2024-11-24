using Domins.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommand.UserUploads
{
    public class DeleteUserUploadCommand : IRequest<UserUpload>
    {
        public int Id { get; set; }
        public DeleteUserUploadCommand(int id)
        {
            Id = id;
        }

    }
}
