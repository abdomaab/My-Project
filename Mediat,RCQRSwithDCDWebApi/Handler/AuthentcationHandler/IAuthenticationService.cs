
using Domins.Sign_In;
using Domins.Sign_Up;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.AuthentcationHandler
{
    public interface IAuthenticationService
    {
        Task<Authentication> RegisterAsync(Registering registering);
        Task<Authentication> SignUpAsync(SigningUp signingUp);
        Task<string> AddToRoleAsync(AddRole role);
    }
}
