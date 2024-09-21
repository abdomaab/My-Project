using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestApi.EF;
using TestApi.EF.Models;
using TestApi.NetCore.Dto;
using TestApi.NetCore.Interfaces;
using TestApi.NetCore.Models;
using TestApi.NetCore.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUnityOfWork _unityOfWork;
        public JWTController(IAuthService authService, IUnityOfWork unityOfWork)
        {
            _authService = authService;
            _unityOfWork = unityOfWork;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ApplicationUser>>> GetAllAsync()
        {
            var users = await _unityOfWork.Users.GetAllUsersAsync();
            return Ok(users);
        }


    }
}
