using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.CustomProducts;
using Handler.MediatorHandler.MediatorCommand.UserUploads;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.UserUploads
{
    public class AddUserUploadValidatorHandler : AbstractValidator<AddUserUploadCommand>
    {
        public AddUserUploadValidatorHandler()
        {
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
            RuleFor(o => o.Image).NotNull().Must(i => i is IFormFile);
            RuleFor(o => o.CustomProductId).NotNull().NotEmpty();
        }
    }
}
