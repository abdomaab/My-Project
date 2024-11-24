using Domins.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        [Required, MaxLength(255), MinLength(5)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public int ZipCode { get; set; }
        [Required,]
        public int Contact { get; set; }
        public int CartId { get; set; }
        

    }
}
