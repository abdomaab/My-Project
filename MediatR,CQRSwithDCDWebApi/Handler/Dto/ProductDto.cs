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
    public class ProductDto
    {
        
        public int Id { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? Image3 { get; set; }
        public string Brand { get; set; } = string.Empty;
        [Required]
        public string Color { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }

        public int CartId { get; set; }
        public int CategoryId { get; set; }
    }
}
