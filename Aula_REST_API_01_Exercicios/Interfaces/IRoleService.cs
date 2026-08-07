using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Interfaces
{
    public interface IRoleService
    {
        public Task<Role?> CreateRoleAsync(string cargo);

        public Task<List<Role?>?> GetAllRolesAsync();

        public Task<Role?> GetRoleAsync(string cargo);

        public Task<Role?> GetRoleIdAsync(int id);

        public Task<List<string?>> GetRoleNameByIdAsync(List<int> RolesIds);
    }
}