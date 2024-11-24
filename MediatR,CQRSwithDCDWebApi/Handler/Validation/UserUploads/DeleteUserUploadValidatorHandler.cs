using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.UserUploads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.UserUploads
{
    public class DeleteUserUploadValidatorHandler : AbstractValidator<DeleteUserUploadCommand>
    {
        public DeleteUserUploadValidatorHandler()
        {
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
