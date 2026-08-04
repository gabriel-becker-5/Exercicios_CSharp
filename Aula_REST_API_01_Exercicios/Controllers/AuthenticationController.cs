using Aula_REST_API_01_Exercicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenservice;

        public AuthenticationController(ITokenService tokenservice)
        {
            _tokenservice = tokenservice;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest login)
        {
            if (login.Email == "admin" && login.Password == "123456")
            {
                var role = "Admin";
                var token = _tokenservice.GerarToken(login.Email, role);
                return Ok(new {token});
            }
            else if (login.Email == "user_comum" && login.Password == "123456")
            {
                var role = "Default";
                var token = _tokenservice.GerarToken(login.Email, role);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}