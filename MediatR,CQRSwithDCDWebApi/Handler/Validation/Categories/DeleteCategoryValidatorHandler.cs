using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.Categories
{
    public class DeleteCategoryValidatorHandler : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidatorHandler()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
