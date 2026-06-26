/* Crie um SaudacaoController com uma Action que cumprimenta o usuário pelo nome.
   - Crie o Controllers/SaudacaoController.cs
   - Crie a Action Ola(string nome) que recebe o nome via query string
   - Retorne Content($"Olá, {nome}! Bem vindo ao ASP.NET Core.")
   - Teste acessando: /Saudacao/Ola?nome=seuNome  */

using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_02_Exercicios.Controllers
{
    public class SaudacaoController : Controller
    {
        [HttpGet]
        public IActionResult Ola(string nome)
        {
            return Content($"Olá, {nome}! Seja bem-vindo ao ASP.Net Core.");
        }
        
        [HttpGet]
        public IActionResult Teste(int id)
        {
            return Content($"Número digitado: {id}.");
        }
    }
}