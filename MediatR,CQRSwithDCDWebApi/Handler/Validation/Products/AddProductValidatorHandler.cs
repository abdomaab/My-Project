using FluentValidation;
using Handler.MediatorHandler.MediatorCommand.Products;
using Handler.MediatorHandler.MediatorCommand.UserUploads;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Validation.Products
{
    public class AddProductValidatorHandler : AbstractValidator<AddProductCommand>
    {
        public AddProductValidatorHandler()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().NotEqual(0);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Image1).NotEmpty().Must(i => i is IFormFile);
            RuleFor(p => p.Image2).Must(i => i is IFormFile);
            RuleFor(p => p.Image3).Must(i => i is IFormFile);
            RuleFor(p => p.Brand).NotEmpty();
            RuleFor(p => p.Color).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.CartId).NotNull().NotEmpty();
            RuleFor(p => p.CategoryId).NotNull().NotEmpty();
        }
    }
}
