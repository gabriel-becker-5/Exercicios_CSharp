using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            List<int> UserRolesInt = await _usuarioService.GetUserRoles(usuario);
            List<string> UserRolesString = await _roleService.GetRoleNameByIdAsync(UserRolesInt);
            var token = _tokenservice.GerarToken(login.Email, UserRolesString);

            return Ok(new { token });
        }
    }
}