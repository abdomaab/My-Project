using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.Carts
{
    public class DeleteCartValidatorHandler : AbstractValidator<DeleteCartCommand>
    {
        public DeleteCartValidatorHandler()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
