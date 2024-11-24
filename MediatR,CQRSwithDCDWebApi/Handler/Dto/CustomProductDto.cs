using Domins.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Dto
{
    public class CustomProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
        [Required]
        public double Cost { get; set; }
        public int UserUploadId { get; set; }
    }
}
