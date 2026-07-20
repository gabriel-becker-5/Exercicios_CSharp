using Aula_MVC_04_Exercicios.Data;
using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task Inicializar(RoleManager<IdentityRole> roleManager, 
                                         UserManager<ApplicationUser> userManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("Professor"))
        {
            await roleManager.CreateAsync(new IdentityRole("Professor"));
        }

        if (!await roleManager.RoleExistsAsync("Aluno"))
        {
            await roleManager.CreateAsync(new IdentityRole("Aluno"));
        }

        var adminUser = await userManager.FindByEmailAsync("admin@email.com");

        if (adminUser == null)
        {
            ApplicationUser newAdmin = new ApplicationUser
            {
                UserName = "admin@email.com",
                Email = "admin@email.com"
            };

            var response = await userManager.CreateAsync(newAdmin, "Senha123!");

            if (response.Succeeded)
            {
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }
    }
};