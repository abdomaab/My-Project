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

namespace Handler.MediatorHandler.MediatorCommand.UserUploads
{
    public class AddUserUploadCommand : IRequest<UserUpload>
    {
        public int Id { get; set; }

        public IFormFile Image { get; set; }  

        public int CustomProductId { get; set; }

        public AddUserUploadCommand(UserUploadDto userUploadDto)
        {
            Id = userUploadDto.Id;
            Image = userUploadDto.Image;
            CustomProductId = userUploadDto.CustomProductId;
        }
    }

}
