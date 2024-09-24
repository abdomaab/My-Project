using System.ComponentModel.DataAnnotations;

namespace SendEmail.Dto
{
    public class WelcomeRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
