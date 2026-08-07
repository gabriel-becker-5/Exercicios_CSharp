using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role> CreateRoleAsync(Role newRole);

        public Task<List<Role?>?> GetAllRolesAsync();

        public Task<bool> RoleEhExistente(string role);

        public Task<Role?> GetRoleAsync(string cargo);
        
        public Task<Role?> GetRoleByIdAsync(int id);

        public Task<string?> GetRoleNameByIdAsync(int id);
    }
}