using Domins.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Dto
{
    public class CartDto
    {
        public int Id { get; set; }
        [Required, MinLength(8), MaxLength(40)]
        public string Custom { get; set; }
        [Required]
        public int Size { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        
        public int OrderId { get; set; }
    }
}
