using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.Categories
{
    public class AddCategoryValidatorHandler : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryValidatorHandler()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().NotEqual(0);
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ProductId).NotNull().NotEmpty();
        }
    }
}
