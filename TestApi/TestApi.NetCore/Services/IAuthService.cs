using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.EF;
using TestApi.EF.Models;
using TestApi.NetCore.Dto;
using TestApi.NetCore.Models;

namespace TestApi.NetCore.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(Models.RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        
    
    }
}
