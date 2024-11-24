using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Dto
{
    public class UserUploadDto
    {
        public int Id { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public int CustomProductId { get; set; }
        
    }
}
