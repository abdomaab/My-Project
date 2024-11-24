using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domins.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Required,MinLength(8), MaxLength(40)]
        public string Custom { get; set; }
        [Required]
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        public int OrderId { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
