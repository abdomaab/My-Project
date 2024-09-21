using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.NetCore.Models;

namespace TestApi.NetCore.Dto
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
}
