using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.AspNetCore.Identity;
using ZendeskApi_v2.Models.Constants;

namespace Aula_REST_API_01_Exercicios.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();

        public async Task<Usuario?> CreateUserAsync(UsuarioDto dto)
        {
            if (await _UsuarioRepository.EmailEhCadastradoAsync(dto.Email))
            {
                return null;
            }

            Usuario novoUsuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email
            };

            var senhaHash = passwordHasher.HashPassword(novoUsuario, dto.Senha);
            novoUsuario.SenhaHash = senhaHash;

            return await _UsuarioRepository.CreateUserAsync(novoUsuario);
        }

        public async Task<UserRole?> CreateUserRoleAsync(Usuario usuario, Role role)
        {
            var resultado = await _UsuarioRepository.UserRoleExists(usuario.Id, role.Id);

            if (resultado)
            {
                return null;
            }

            UserRole newUserRole = new UserRole
            {
                Role = role,
                Usuario = usuario
            };

            return await _UsuarioRepository.CreateUserRoleAsync(newUserRole);
        }

        public async Task RemoveRoleFromUserAsync(Usuario usuario, Role role)
        {
            await _UsuarioRepository.RemoveRoleFromUserAsync(usuario.Id, role.Id);
        }

        public async Task RemoveAllRolesFromUserAsync(Usuario usuario)
        {
            await _UsuarioRepository.RemoveAllRolesFromUserAsync(usuario.Id);
        }

        public async Task<Usuario?> GetUserByEmailAsync(string email)
        {
            var resultado = await _UsuarioRepository.BuscarPorEmailAsync(email);

            if (resultado != null)
            {
                return resultado;
            }

            return null;
        }

        public async Task<Usuario?> GetUserByIdAsync(int id)
        {
            return await _UsuarioRepository.BuscarPorIdAsync(id);
        }

        public PasswordVerificationResult GetSenhaCorreta(Usuario usuario, string senhaDto)
        {
            return passwordHasher.VerifyHashedPassword(usuario, usuario.SenhaHash, senhaDto);
        }

        public async Task<List<int>> GetUserRoles(Usuario usuario)
        {
            List<UserRole?> rolesDoUser = await _UsuarioRepository.GetUserRoles(usuario.Id);

            List<int> rolesInt = [];

            foreach (UserRole role in rolesDoUser)
            {
                rolesInt.Add(role.RoleId);
            }

            return rolesInt;
        }

        public async Task<List<UserRoleDto?>> GetUserRolesObject(Usuario usuario)
        {
            List<UserRole> allUserRoles = await _UsuarioRepository.GetUserRoles(usuario.Id);
            List<UserRoleDto> allUserRolesDto = [];

            for (int i = 0; i < allUserRoles.Count; i++)
            {
                //UserRoleDto userRoleDTO = new()
                //{
                //    allUserRolesDto[i].Id = allUserRoles[i].Id,
                //    allUserRolesDto[i].UsuarioId = allUserRoles[i].UsuarioId,
                //    allUserRolesDto[i].RoleId = allUserRoles[i].RoleId
                //};



            }

            return allUserRolesDto;
        }

        public async Task<List<Usuario>> GetAllUsersAsync()
        {
            return await _UsuarioRepository.ListarTodosAsync();
        }

        public async Task UpdateUserAsync(UsuarioUpdateDto dto, Usuario usuario)
        {
            usuario.Email = dto.Email;
            usuario.Nome = dto.Nome;
            await _UsuarioRepository.UpdateUserAsync(usuario);
        }

        public async Task DeleteUserAsync(Usuario usuario)
        {
            await _UsuarioRepository.DeleteUserAsync(usuario);
        }
    }
}