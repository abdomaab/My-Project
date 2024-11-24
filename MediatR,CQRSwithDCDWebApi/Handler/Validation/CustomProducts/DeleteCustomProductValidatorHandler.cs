using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.CustomProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.CustomProducts
{
    public class DeleteCustomProductValidatorHandler : AbstractValidator<DeleteCustomProductCommand>
    {
        public DeleteCustomProductValidatorHandler()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
