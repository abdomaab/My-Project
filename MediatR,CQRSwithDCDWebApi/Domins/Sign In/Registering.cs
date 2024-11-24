using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domins.Sign_In
{
    public class Registering
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(50), RegularExpression("^[a-z0-9_-]{3,15}$")]
        public string Username { get; set; }

        [Required, StringLength(128), EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(256), RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$")]
        public string Password { get; set; }
        [Required, RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")]
        public int Contact { get; set; }
    }
}
