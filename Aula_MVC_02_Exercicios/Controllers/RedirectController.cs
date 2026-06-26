/* Pratique o uso de RedirectToAction entre diferentes Actions
   - Crie a Action Antiga() que sempre redireciona para Nova()
   - Crie a Action Nova() que retorna Content("Você está na versão nova!")
   - Use RedirectToAction("Nova") dentro de Antiga()
   - Acesse /produtos/antiga e observe a URL mudar no navegador após o redirecionamento */

using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_02_Exercicios.Controllers
{
    public class RedirectController : Controller
    {
        [HttpGet]
        public IActionResult Antiga()
        {
            return Redirect("Nova");
        }

        [HttpGet]
        public IActionResult Nova()
        {
            return Content("Você está na versão nova!");
        }
    }
}