using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domins.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public string Brand { get; set; } = string.Empty;
        [Required]
        public string Color { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }

        public int CartId { get; set; }
        public IList<Cart> Carts { get; set; }
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
    }
}
