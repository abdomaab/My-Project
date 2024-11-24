using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.Orders
{
    public class DeleteOrderValidatorHandler : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderValidatorHandler()
        {
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
