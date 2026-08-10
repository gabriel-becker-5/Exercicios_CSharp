using Aula_REST_API_01_Exercicios.Authorization;
using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Data
{
    public static class SeedData
    {
        public static async Task Initializer(IRoleService roleservice, IUsuarioService usuarioservice)
        {
            // Cria todas as roles se não existirem
            for (int i = 0; i < Roles.roles.Length; i++)
            {
                await roleservice.CreateRoleAsync(Roles.roles[i]);
            }

            // Cria Usuário Inicial
            UsuarioDto dto = new UsuarioDto
            {
                Email = "admin@admin.com",
                Nome = "Admin",
                Senha = "123"
            };

            Usuario? usuario = await usuarioservice.CreateUserAsync(dto);

            // Atribui Role Admin ao Usuário Inicial
            Role? roleAdmin = await roleservice.GetRoleAsync(Roles.Admin);

            if (usuario != null && roleAdmin != null)
            {
                await usuarioservice.CreateUserRoleAsync(usuario, roleAdmin);
            }
        }
    }
}