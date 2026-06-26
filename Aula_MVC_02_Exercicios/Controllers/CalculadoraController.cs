/* Crie Actions que realizam operações matemáticas recebendo parâmetros pela URL
- Crie CalculadoraController com [Route("calculadora")]
- Crie a Action Somar(int a, int b) com [HttpGet("somar")]
- Crie também Subtrair, Multiplicar e Dividir seguindo o mesmo padrão
- Retorne o resultado formatado com Content()
- Teste através do link: /calculadora/somar?a=5&b=3 */

using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_02_Exercicios.Controllers
{
    [Route("calculadora")]
    public class CalculadoraController : Controller
    {
        [HttpGet("somar")]
        public IActionResult Somar(int numero1, int numero2)
        {
            int resultado = numero1 + numero2;
            return Content($"Somando {numero1} + {numero2}, resultado: {resultado}.");
        }

        [HttpGet("subtrair")]
        public IActionResult Subtrair(int numero1, int numero2)
        {
            int resultado = numero1 - numero2;
            return Content($"Subtraindo {numero2} - {numero1}, resultado: {resultado}.");
        }

        [HttpGet("multiplicar")]
        public IActionResult Multiplicar(int numero1, int numero2)
        {
            int resultado = numero1 * numero2;
            return Content($"Multiplicando {numero1} * {numero2}, resultado: {resultado}.");
        }

        [HttpGet("dividir")]
        public IActionResult Dividir(int numero1, int numero2)
        {
            int resultado = numero1 / numero2;
            return Content($"Dividindo {numero1} / {numero2}, resultado: {resultado}.");
        }
    }
}