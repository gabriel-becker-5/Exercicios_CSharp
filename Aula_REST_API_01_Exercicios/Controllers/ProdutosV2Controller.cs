using Asp.Versioning;
using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProdutosV2Controller : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosV2Controller(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Lista todos os produtos cadastrados.
        /// </summary>
        /// <returns>Lista com todos os produtos ou lista vazia.</returns>
        /// <response code="200">Sucesso.</response>
        [ProducesResponseType(200)]
        [HttpGet("listarTodos")]
        public async Task<IActionResult> GetTodosAsync()
        {
            List<Produto> produtosCadastrados = await _produtoService.GetTodosAsync();
            return Ok(produtosCadastrados);
        }
    }
}