
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

namespace Handler.MediatorHandler.MediatorCommand.CustomProducts
{
    public class AddCustomProductCommand : IRequest<CustomProduct>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public IFormFile Image { get; set; }
        public double Cost { get; set; }
        public int UserUploadId { get; set; }

        public AddCustomProductCommand(CustomProductDto customProductDto)
        {
            Id = customProductDto.Id;
            Title = customProductDto.Title;
            Cost = customProductDto.Cost;
            Image = customProductDto.Image;
            UserUploadId = customProductDto.UserUploadId;
        }
    }
}
