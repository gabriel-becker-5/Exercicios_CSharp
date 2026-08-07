using Aula_REST_API_01_Exercicios.Models;
using Microsoft.AspNetCore.Identity;

namespace Aula_REST_API_01_Exercicios.Interfaces
{
    public interface IUsuarioService
    {
        public Task<Usuario> CreateUserAsync(UsuarioDto dto);

        public Task<UserRole?> CreateUserRoleAsync(Usuario usuario, Role role);

        public Task RemoveRoleFromUserAsync(Usuario usuario, Role role);

        public Task RemoveAllRolesFromUserAsync(Usuario usuario);

        public Task<Usuario?> GetUserByEmailAsync(string email);

        public Task<Usuario?> GetUserByIdAsync(int id);

        public PasswordVerificationResult GetSenhaCorreta(Usuario usuario, string senhaDto);

        public Task<List<int>> GetUserRoles(Usuario usuario);

        public Task<List<UserRoleDto?>> GetUserRolesObject(Usuario usuario);

        public Task<List<Usuario>> GetAllUsersAsync();

        public Task UpdateUserAsync(UsuarioUpdateDto dto, Usuario usuario);

        public Task DeleteUserAsync(Usuario usuario);
    }
}