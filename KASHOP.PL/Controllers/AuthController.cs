using KASHOP.BLL;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest Request)
        {
            var (success, errors) = await _authService.RegisterAsync(Request);
                return success ? Ok() : BadRequest(new { errors });
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest Request)
        {
            var (success, errors , response) = await _authService.LoginAsync(Request);
            return success ? Ok(response) : BadRequest(new { errors });
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId , [FromQuery] string token)
        {
            var (success, errors) = await _authService.ConfirmEmailAsync(userId , token);
            return success ? Ok("done") : BadRequest(new { errors });
        }

    }
}
