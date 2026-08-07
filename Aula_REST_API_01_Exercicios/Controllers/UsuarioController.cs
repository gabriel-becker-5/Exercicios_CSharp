using Aula_REST_API_01_Exercicios.Authorization;
using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IRoleService _roleService;

        public UsuarioController(IUsuarioService usuarioservice,
                                        IRoleService roleService)
        {
            _usuarioService = usuarioservice;
            _roleService = roleService;
        }

        private string? ObterEmailUsuarioLogado()
        {
            return User.FindFirstValue(JwtRegisteredClaimNames.Name);
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<IActionResult> CadastrarAsync(UsuarioDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Role role = await _roleService.GetRoleAsync(Roles.Default);

            if (role == null)
            {
                return BadRequest();
            }

            Usuario novoUsuario = await _usuarioService.CreateUserAsync(dto);

            if (novoUsuario == null)
            {
                return BadRequest();
            }

            await _usuarioService.CreateUserRoleAsync(novoUsuario, role);

            return CreatedAtAction(nameof(GetUserByIdAsync),
                new { id = novoUsuario.Id },
                novoUsuario);
        }

        [HttpGet("listarTodos")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var resultado = await _usuarioService.GetAllUsersAsync();

            if (resultado == null)
            {
                return NoContent();
            }

            return Ok(resultado);
        }

        [ActionName(nameof(GetUserByIdAsync))]
        [HttpGet("pesquisaPorId")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var resultado = await _usuarioService.GetUserByIdAsync(id);

            if (resultado == null)
            {
                return NoContent();
            }

            return Ok(resultado);
        }

        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPut("atualizaCadastro")]
        [Authorize]
        public async Task<IActionResult> UpdateUserAsync(UsuarioUpdateDto dto)
        {
            string? emailUsuario = ObterEmailUsuarioLogado();

            if (emailUsuario == null)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // FALTA VALIDAR SE O E-MAIL JÁ ESTÁ CADASTRADO ANTES DE ATUALIZAR ELE PARA OUTRA CONTA.

            Usuario usuarioLogado = await _usuarioService.GetUserByEmailAsync(emailUsuario);

            await _usuarioService.UpdateUserAsync(dto, usuarioLogado);

            return Ok();
        }

        [ProducesResponseType(401)]
        [ProducesResponseType(204)]
        [HttpDelete("deletaCadastro")]
        [Authorize(Roles = Roles.Default)]
        public async Task<IActionResult> DeleteUserAsync()
        {
            string? emailUsuario = ObterEmailUsuarioLogado();

            if (emailUsuario == null)
            {
                return Unauthorized();
            }
            
            Usuario usuarioLogado = await _usuarioService.GetUserByEmailAsync(emailUsuario);

            await _usuarioService.DeleteUserAsync(usuarioLogado);
            return NoContent();

            // Adicionar chamada à Revogar Roles do Usuário também
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("deletaCadastroAdm")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AdminDeleteUserAsync(string emailUsuario)
        {
            if (emailUsuario.IsNullOrEmpty())
            {
                return NotFound();
            }

            Usuario usuarioLogado = await _usuarioService.GetUserByEmailAsync(emailUsuario);
            await _usuarioService.DeleteUserAsync(usuarioLogado);
            return NoContent();

            // Adicionar chamada à Revogar Roles do Usuário também
        }

        [HttpGet("listarRoles")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            return Ok(await _roleService.GetAllRolesAsync());
        }

        [HttpGet("pesquisaRoleId")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetRoleByIdAsync(int roleId)
        {
            var resultado = await _roleService.GetRoleIdAsync(roleId);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpPost("atribuirRoleUsuario")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AddRoleToUserAsync(string emailUsuario, string cargo)
        {
            Usuario? usuario = await _usuarioService.GetUserByEmailAsync(emailUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            Role? role = await _roleService.GetRoleAsync(cargo);

            if (role == null)
            {
                return NotFound();
            }

            await _usuarioService.CreateUserRoleAsync(usuario, role);
            return Ok();
        }

        [HttpDelete("revogarRoleUsuario")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> RemoveRoleFromUserAsync(string emailUsuario, string cargo)
        {
            Usuario? usuario = await _usuarioService.GetUserByEmailAsync(emailUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            Role? role = await _roleService.GetRoleAsync(cargo);

            if (role == null)
            {
                return NotFound();
            }

            await _usuarioService.RemoveRoleFromUserAsync(usuario, role);
            return Ok();
        }

        [HttpDelete("revogarTodasRoles")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> RemoveAllRolesFromUserAsync(string emailUsuario)
        {
            Usuario? usuario = await _usuarioService.GetUserByEmailAsync(emailUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioService.RemoveAllRolesFromUserAsync(usuario);

            return Ok();
        }

        [HttpGet("exibirRolesUsuario")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> ListUserRolesAsync(string emailUsuario)
        {
            Usuario? usuario = await _usuarioService.GetUserByEmailAsync(emailUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            List<UserRoleDto> allUserRoles = await _usuarioService.GetUserRolesObject(usuario);

            return Ok(allUserRoles);
        }
    }
}