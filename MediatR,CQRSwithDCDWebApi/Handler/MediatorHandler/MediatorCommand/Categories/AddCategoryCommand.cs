using Domins.Models;
using Handler.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommand.Categories
{
    public class AddCategoryCommand : IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ProductId { get; set; }

        public AddCategoryCommand( CategoryDto categoryDto)
        {
            Id = categoryDto.Id;
            Name = categoryDto.Name;
            Description = categoryDto.Description;
            ProductId = categoryDto.ProductId;
        }
    }
}
