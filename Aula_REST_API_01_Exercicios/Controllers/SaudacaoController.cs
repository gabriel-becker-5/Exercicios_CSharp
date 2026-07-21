using Microsoft.AspNetCore.Mvc;
using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaudacaoController : ControllerBase
    {
        [HttpGet("{nome}")]
        public IActionResult SaudacaoPersonalizada(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                Saudacao saudacao = new Saudacao
                {
                    Nome = nome,
                    DataHoraAgora = DateTime.Now,
                    SaudacaoPersonalizada = $"Olá querido usuário {nome}, seja bem-vindo!"
                };

                return Ok(saudacao);
            }

            var erroNomeObrigatorio = new {erro = "O nome é obrigatório"};
            return BadRequest(erroNomeObrigatorio);
        }
    }
}