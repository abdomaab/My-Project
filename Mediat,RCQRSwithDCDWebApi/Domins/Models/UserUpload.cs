using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domins.Models
{
    public class UserUpload
    {
        public int Id { get; set; }
        [Required]
        public byte[] Image { get; set; }
        public int CustomProductId { get; set; }
        public CustomProduct CustomProduct { get; set; }
    }
}
