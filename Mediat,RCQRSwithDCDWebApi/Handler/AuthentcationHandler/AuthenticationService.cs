
using Domins;
using Domins.Sign_In;
using Domins.Sign_Up;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Handler.AuthentcationHandler
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        public AuthenticationService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }

        public async Task<string> AddToRoleAsync(AddRole role)
        {
            var user = await _userManager.FindByIdAsync(role.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(role.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, role.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, role.Role);

            return result.Succeeded ? string.Empty : "Something went wrong";
        }

      

        public async Task<Authentication> GetTokenAsync(SigningUp signingUp)
        {
            var authModel = new Authentication();

            var user = await _userManager.FindByEmailAsync(signingUp.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, signingUp.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.UserName = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;
        }


        public async Task<Authentication> RegisterAsync(Registering registering)
        {
            if (await _userManager.FindByEmailAsync(registering.Email) is not null)
                return new Authentication { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(registering.Username) is not null)
                return new Authentication { Message = "Username is already registered!" };

            var user = new ApplicationUser
            {
                UserName = registering.Username,
                Email = registering.Email,
                FirstName = registering.FirstName,
                LastName = registering.LastName
            };

            var result = await _userManager.CreateAsync(user, registering.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new Authentication { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJwtToken(user);

            return new Authentication
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName
            };
        }

       

        public Task<Authentication> SignUpAsync(SigningUp signingUp)
        {
            throw new NotImplementedException();
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                //expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
