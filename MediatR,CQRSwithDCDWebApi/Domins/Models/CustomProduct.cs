using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domins.Models
{
    public class CustomProduct
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
       // [Required]
        public byte[] Image { get; set; }
        [Required]
        public double Cost { get; set; }
        public int UserUploadId { get; set; }
        public IList<UserUpload> UserUploads { get; set; } = new List<UserUpload>();
    }
}
