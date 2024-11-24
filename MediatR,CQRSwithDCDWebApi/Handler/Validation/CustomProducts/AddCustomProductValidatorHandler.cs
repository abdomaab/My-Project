using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.CustomProducts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.CustomProducts
{
    public class AddCustomProductValidatorHandler : AbstractValidator<AddCustomProductCommand>
    {
        public AddCustomProductValidatorHandler()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().NotEqual(0);
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Image).NotNull().Must(i => i is IFormFile);
            RuleFor(c => c.Cost).NotEmpty();
            RuleFor(c => c.UserUploadId).NotNull().NotEmpty();
        }
    }
}
