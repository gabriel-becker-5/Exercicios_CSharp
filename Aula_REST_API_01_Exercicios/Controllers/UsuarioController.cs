using Asp.Versioning;
using Aula_REST_API_01_Exercicios.Authorization;
using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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

        /// <summary>
        /// Cadastra novo usuário no banco de dados.
        /// </summary>
        /// <param name="dto">Campos: Nome do usuário, E-mail e Senha.</param>
        /// <returns>O cadastro do usuário criado.</returns>
        /// <response code="201">Usuário criado.</response>
        /// <response code="400">Informações fornecidas inválidas.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// Lista todos os usuários cadastrados no banco de dados.
        /// </summary>
        /// <returns>Retorna lista de usuários ou lista vazia.</returns>
        /// <response code="200">Ok, lista de usuários.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("listarTodos")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var resultado = await _usuarioService.GetAllUsersAsync();

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        /// <summary>
        /// Pesquisa um usuário pelo ID do cadastro.
        /// </summary>
        /// <param name="id">ID única do usuário.</param>
        /// <returns>O cadastro do usuário, se for localizado.</returns>
        /// <response code="200">Ok, retorna cadastro.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ActionName(nameof(GetUserByIdAsync))]
        [HttpGet("pesquisaPorId")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var resultado = await _usuarioService.GetUserByIdAsync(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        /// <summary>
        /// Atualiza o cadastro do usuário logado.
        /// </summary>
        /// <param name="dto">Campos: Nome do usuário, E-mail e Senha.</param>
        /// <response code="200">Ok, cadastro atualizado.</response>
        /// <response code="400">Informações fornecidas inválidas.</response>
        /// <response code="401">Não autorizado, email já cadastrado em outra conta.</response>
        /// <response code="404">Usuário não localizado.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [HttpPut("atualizaCadastro")]
        [Authorize]
        public async Task<IActionResult> UpdateUserAsync(UsuarioUpdateDto dto)
        {
            string? emailUsuario = ObterEmailUsuarioLogado();

            if (emailUsuario == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            Usuario usuarioLogado = await _usuarioService.GetUserByEmailAsync(emailUsuario);
            
            if (usuarioLogado == null)
            {
                return NotFound();
            }

            if (await _usuarioService.EmailEhCadastradoAsync(dto.Email))
            {
                return Unauthorized();
            }

            if (dto.Email == usuarioLogado.Email)
            {
                return Unauthorized();
            }

            await _usuarioService.UpdateUserAsync(dto, usuarioLogado);
            return Ok();
        }

        /// <summary>
        /// Deleta o cadastro do usuário logado.
        /// </summary>
        /// <response code="204">Ok, cadastro deletado.</response>
        /// <response code="400">Informações inseridas inválidas.</response>
        /// <response code="404">Usuário não cadastrado.</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [HttpDelete("deletaCadastro")]
        [Authorize(Roles = Roles.Default)]
        public async Task<IActionResult> DeleteUserAsync()
        {
            string? emailUsuario = ObterEmailUsuarioLogado();

            if (emailUsuario == null)
            {
                return BadRequest();
            }
            
            Usuario usuarioLogado = await _usuarioService.GetUserByEmailAsync(emailUsuario);

            if (usuarioLogado == null)
            {
                return NotFound();
            }

            await _usuarioService.DeleteUserAsync(usuarioLogado);
            return NoContent();
        }

        /// <summary>
        /// Admin - Deletar qualquer usuário pelo e-mail.
        /// </summary>
        /// <param name="emailUsuario">E-mail do usuário.</param>
        /// <response code="204">Ok, cadastro deletado.</response>
        /// <response code="400">Informações inseridas inválidas.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpDelete("deletaCadastroAdm")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AdminDeleteUserAsync(string emailUsuario)
        {
            if (emailUsuario.IsNullOrEmpty())
            {
                return BadRequest();
            }

            Usuario usuarioLogado = await _usuarioService.GetUserByEmailAsync(emailUsuario);

            if (usuarioLogado == null)
            {
                return NotFound();
            }

            await _usuarioService.DeleteUserAsync(usuarioLogado);
            return NoContent();
        }

        /// <summary>
        /// Lista todas as roles existentes.
        /// </summary>
        /// <response code="200">Ok, retorna lista de roles ou lista vazia.</response>
        [ProducesResponseType(200)]
        [HttpGet("listarRoles")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            return Ok(await _roleService.GetAllRolesAsync());
        }

        /// <summary>
        /// Pesquisa role pelo ID do cadastro.
        /// </summary>
        /// <param name="roleId">ID única da role no banco de dados.</param>
        /// <returns>A role, se for localizada.</returns>
        /// <response code="200">Ok, retorna role.</response>
        /// <response code="404">Role não encontrada.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Concede acesso de uma role a um usuário informado.
        /// </summary>
        /// <param name="emailUsuario">E-mail do usuário.</param>
        /// <param name="cargo">Cargo a ser liberada permissão.</param>
        /// <response code="200">Ok, permissão concedida.</response>
        /// <response code="404">Usuário ou Role não encontrados.</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Revoga o acesso à role do usuário informado.
        /// </summary>
        /// <param name="emailUsuario">E-mail do usuário.</param>
        /// <param name="cargo">Cargo a ser liberada permissão.</param>
        /// <response code="200">Ok, acesso removido.</response>
        /// <response code="404">Usuário ou Role não encontrados.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Revoga o acesso à todas as roles do usuário informado.
        /// </summary>
        /// <param name="emailUsuario">E-mail do usuário.</param>
        /// <response code="200">Ok, acessos removidos.</response>
        /// <response code="404">Usuário ou Role não encontrados.</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Lista todas as roles que o usuário informado tem permissão.
        /// </summary>
        /// <param name="emailUsuario">E-mail do usuário.</param>
        /// <returns>Lista de roles do usuário.</returns>
        /// <response code="200">Ok, retorna lista de roles do usuário.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("exibirRolesUsuario")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> ListUserRolesAsync(string emailUsuario)
        {
            Usuario? usuario = await _usuarioService.GetUserByEmailAsync(emailUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            List<int> allUserRolesInt = await _usuarioService.GetUserRolesAsync(usuario);
            List<string> allUserRolesString = await _roleService.GetRoleNameByIdAsync(allUserRolesInt);
            List<UserRoleDto> allUserRoles = [];

            for (int i = 0; i < allUserRolesInt.Count; i++)
            {
                UserRoleDto novoUserRoleDto = new UserRoleDto
                {
                    RoleId = allUserRolesInt[i],
                    RoleName = allUserRolesString[i]
                };

                allUserRoles.Add(novoUserRoleDto);
            }

            return Ok(allUserRoles);
        }
    }
}