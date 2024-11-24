using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.Products
{
    public class DeleteProductValidatorHandler : AbstractValidator<DeleteProductrCommand>
    {
        public DeleteProductValidatorHandler()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
