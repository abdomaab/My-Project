using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.CustomProducts;
using Handler.MediatorHandler.MediatorCommand.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.Orders
{
    public class AddOrderValidatorHandler : AbstractValidator<AddOrderCommand>
    {
        public AddOrderValidatorHandler()
        {
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
            RuleFor(o => o.Name).NotEmpty();
            RuleFor(o => o.Address).NotEmpty();
            RuleFor(o => o.City).NotEmpty();
            RuleFor(o => o.ZipCode).NotNull().NotEmpty();
            RuleFor(o => o.Contact).NotNull().NotEmpty();
            RuleFor(o => o.CartId).NotNull().NotEmpty();
        }
    }
}
