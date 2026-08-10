using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _RoleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _RoleRepository = roleRepository;
        }

        public async Task<Role?> CreateRoleAsync(string cargo)
        {
            bool resultado = await _RoleRepository.RoleEhExistente(cargo);

            if (resultado)
            {
                return null;
            }

            Role newRole = new Role
            {
                Cargo = cargo
            };

            return await _RoleRepository.CreateRoleAsync(newRole);
        }

        public async Task<List<Role?>> GetAllRolesAsync()
        {
            return await _RoleRepository.GetAllRolesAsync();
        }

        public async Task<Role?> GetRoleAsync(string cargo)
        {
            Role? role = await _RoleRepository.GetRoleAsync(cargo);

            if (role == null)
            {
                return null;
            }
            return role;
        }

        public async Task<Role?> GetRoleIdAsync(int id)
        {
            return await _RoleRepository.GetRoleByIdAsync(id);
        }

        public async Task<List<string?>> GetRoleNameByIdAsync(List<int> RolesIds)
        {
            List<string> roles = [];

            foreach (int roleId in RolesIds)
            {
                var resposta = await _RoleRepository.GetRoleNameByIdAsync(roleId);
                roles.Add(resposta);
            }

            return roles;
        }
    }
}