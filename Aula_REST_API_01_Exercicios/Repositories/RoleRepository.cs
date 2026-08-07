using Aula_REST_API_01_Exercicios.Data;
using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula_REST_API_01_Exercicios.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Role> CreateRoleAsync(Role newRole)
        {
            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();
            return(newRole);
        }

        public async Task<List<Role?>?> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<bool> RoleEhExistente(string cargo)
        {
            Role? resultado = await _context.Roles.Where(r => r.Cargo == cargo).FirstOrDefaultAsync();

            if (resultado == null)
            {
                return false;
            }

            return true;
        }

        public async Task<Role?> GetRoleAsync(string cargo)
        {
            Role? resultado = await _context.Roles.Where(r => r.Cargo == cargo).FirstOrDefaultAsync();
            if (resultado == null)
            {
                return null;
            }
            return resultado;
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            Role? resultado = await _context.Roles.FindAsync(id);

            if (resultado == null)
            {
                return null;
            }
            return resultado;
        }

        public async Task<string?> GetRoleNameByIdAsync(int id)
        {
            Role? resultado = await _context.Roles.FindAsync(id);

            if (resultado != null)
            {
                return resultado.Cargo.ToString();
            }
            
            return null;
        }
    }
}