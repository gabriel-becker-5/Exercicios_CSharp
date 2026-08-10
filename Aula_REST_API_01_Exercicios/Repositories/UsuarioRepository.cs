using Aula_REST_API_01_Exercicios.Data;
using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula_REST_API_01_Exercicios.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ListarTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> BuscarPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario?> BuscarPorEmailAsync(string email)
        {
            Usuario? resultado = await _context.Usuarios.Where(u => u.Email == email).FirstOrDefaultAsync();
            
            if (resultado == null)
            {
                return null;
            }

            return resultado;
        }

        public async Task<bool> EmailEhCadastradoAsync(string email)
        {
            Usuario? resultado = await _context.Usuarios.Where(u => u.Email == email).FirstOrDefaultAsync();

            if (resultado == null)
            {
                return false;
            }

            return true;
        }

        public async Task<Usuario> CreateUserAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task UpdateUserAsync(Usuario usuario)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<UserRole> CreateUserRoleAsync(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();
            return userRole;
        }

        public async Task RemoveRoleFromUserAsync(int userId, int roleId)
        {
            UserRole? resultado = await _context.UserRoles.Where(ur => ur.UsuarioId == userId &&
                                                                 ur.RoleId == roleId).
                                                                 FirstOrDefaultAsync();
            if (resultado != null)
            {
                _context.UserRoles.Remove(resultado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAllRolesFromUserAsync(int userId)
        {
            List<UserRole> allUserRoles = await _context.UserRoles.Where(ur => ur.UsuarioId == userId)
                                                          .ToListAsync();
            
            foreach (UserRole userRole in allUserRoles)
            {
                _context.UserRoles.Remove(userRole);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserRoleExists(int userId, int roleId)
        {
            UserRole? resultado = await _context.UserRoles.Where(ur => ur.UsuarioId == userId && 
                                                                 ur.RoleId    == roleId).
                                                                 FirstOrDefaultAsync();

            if (resultado == null)
            {
                return false;
            }

            return true;
        }

        public async Task<List<UserRole?>> GetUserRoles(int userId)
        {
            List<UserRole> rolesDoUsuario = await _context.UserRoles.Where(ur => ur.UsuarioId == userId).ToListAsync();
            return rolesDoUsuario;
        }
    }
}