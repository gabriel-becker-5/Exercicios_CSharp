using Aula_MVC_04_Exercicios.Data;
using Aula_MVC_04_Exercicios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_04_Exercicios.Controllers
{
    [Authorize]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(RoleManager<IdentityRole> rolemanager, 
                               UserManager<ApplicationUser> usermanager)
        {
            _roleManager = rolemanager;
            _userManager = usermanager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult PainelAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("atribuiruserrole")]
        public async Task<IActionResult> AtribuirUserRole(AlterarRoleViewModel model)
        {
            ApplicationUser usuario = await _userManager.FindByEmailAsync(model.userEmail);
            if (usuario == null) 
            {
                return View("PainelAdmin");
            }
            await _userManager.AddToRoleAsync(usuario, model.Role);
            return View("PainelAdmin");
        }
    }
}