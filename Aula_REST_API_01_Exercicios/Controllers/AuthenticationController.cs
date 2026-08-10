using Asp.Versioning;
using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenservice;
        private readonly IUsuarioService _usuarioService;
        private readonly IRoleService _roleService;

        public AuthenticationController(ITokenService tokenservice, 
                                        IUsuarioService usuarioservice,
                                        IRoleService roleService)
        {
            _tokenservice = tokenservice;
            _usuarioService = usuarioservice;
            _roleService = roleService;
        }

        /// <summary>
        /// Logar no sistema e gerar token JWT.
        /// </summary>
        /// <response code="200">Credenciais corretas.</response>
        /// <response code="401">Não autorizado, login/senha incorretos.</response>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            Usuario? usuario = await _usuarioService.GetUserByEmailAsync(login.Email);

            if (usuario == null)
            {
                return Unauthorized();
            }

            PasswordVerificationResult senhaEstaCorreta = _usuarioService.GetSenhaCorreta(usuario, login.Password);

            if (senhaEstaCorreta != PasswordVerificationResult.Success)
            {
                return Unauthorized();
            }

            List<int> UserRolesInt = await _usuarioService.GetUserRolesAsync(usuario);
            List<string> UserRolesString = await _roleService.GetRoleNameByIdAsync(UserRolesInt);
            var token = _tokenservice.GerarToken(login.Email, UserRolesString);

            return Ok(new { token });
        }
    }
}