using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.EF.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }

        //public string AspNetUserId { get; set; } // Foreign key property
        //public virtual IdentityUser AspNetUsers { get; set; } // Navigation property
    }

}
