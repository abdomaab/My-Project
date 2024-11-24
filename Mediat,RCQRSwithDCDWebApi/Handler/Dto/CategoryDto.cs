using Domins.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Dto
{
    public class CategoryDto
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ProductId { get; set; }
    }
}
