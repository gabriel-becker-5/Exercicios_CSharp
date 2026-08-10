using Microsoft.AspNetCore.Mvc;
using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaudacaoController : ControllerBase
    {
        /// <summary>
        /// Saudação Personalizada - exercício de aulas anteriores.
        /// </summary>
        /// <param name="nome">Nome do usuário.</param>
        /// <returns>Retorna uma saudação personalizada com o nome informado.</returns>

        /// <response code="200">Ok, retorna saudação.</response>
        /// <response code="400">Preenchimento incorreto.</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
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