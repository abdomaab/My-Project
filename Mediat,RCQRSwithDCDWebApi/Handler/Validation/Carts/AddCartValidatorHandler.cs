using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.Carts
{
    public class AddCartValidatorHandler : AbstractValidator<AddCartCommand>
    {
        public AddCartValidatorHandler()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().NotEqual(0);
            RuleFor(c => c.Custom).NotEmpty();
            RuleFor(c => c.Size).NotEmpty();
            RuleFor(c => c.Quantity).NotEmpty();
            RuleFor(c => c.OrderId).NotNull().NotEmpty();
            RuleFor(c => c.ProductId).NotNull().NotEmpty();
        }
    }
}
