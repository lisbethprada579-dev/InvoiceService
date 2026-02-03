using InvoiceService.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceService.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper _jwtHelper;

        public AuthController(IConfiguration config)
        {
            _jwtHelper = new JwtHelper(config);
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            var token = _jwtHelper.GenerateToken();
            return Ok(new { token });
        }
    }
}
