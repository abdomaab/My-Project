using Domins.Models;
using Handler.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommand.Products
{
    public class AddProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public double Price { get; set; }
        public int CartId { get; set; }
        public int CategoryId { get; set; }

        public AddProductCommand(ProductDto productDto)
        {
            Id = productDto.Id;
            Name = productDto.Name;
            Description = productDto.Description;
            Image1 = productDto.Image1;
            Image2 = productDto.Image2;
            Image3 = productDto.Image3;
            Brand = productDto.Brand;
            Color = productDto.Color;
            Price = productDto.Price;
            CartId = productDto.CartId;
            CategoryId = productDto.CategoryId;
        }
    }
}
