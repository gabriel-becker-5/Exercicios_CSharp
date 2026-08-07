using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<List<Usuario>> ListarTodosAsync();

        public Task<Usuario?> BuscarPorIdAsync(int id);

        public Task<Usuario?> BuscarPorEmailAsync(string email);

        public Task<bool> EmailEhCadastradoAsync(string email);

        public Task<Usuario> CreateUserAsync(Usuario usuario);

        public Task UpdateUserAsync(Usuario usuario);

        public Task DeleteUserAsync(Usuario usuario);

        public Task<UserRole> CreateUserRoleAsync(UserRole userRole);

        public Task RemoveRoleFromUserAsync(int userId, int roleId);

        public Task RemoveAllRolesFromUserAsync(int userId);

        public Task<bool> UserRoleExists(int userId, int roleId);

        public Task<List<UserRole?>> GetUserRoles(int userId);
    }
}