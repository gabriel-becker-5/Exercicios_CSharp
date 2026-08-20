using Asp.Versioning;
using Aula_REST_API_01_Exercicios.Authorization;
using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
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
        [Authorize(Roles = $"{Roles.Admin},{Roles.Default}")]
        public async Task<IActionResult> GetTodosAsync()
        {
            List<Produto> produtosCadastrados = await _produtoService.GetTodosAsync();
            return Ok(produtosCadastrados);
        }

        /// <summary>
        /// Pesquisa um produto pela sua Id.
        /// </summary>
        /// <param name="id">ID única do produto.</param>
        /// <returns>O cadastro do produto correspondente ao ID informado.</returns>
        /// <response code="200">Produto encontrado.</response>
        /// <response code="404">Produto não encontrado.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ActionName(nameof(GetPorIdAsync))]
        [HttpGet("buscar/{id}")]
        [Authorize(Roles = $"{Roles.Admin},{Roles.Default}")]
        public async Task<IActionResult> GetPorIdAsync(int id)
        {
            Produto produto = await _produtoService.GetPorIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        /// <summary>
        /// Cadastra um produto novo no banco de dados.
        /// </summary>
        /// <param name="dto">Campos: Nome do Produto, Preço e Email do fornecedor.</param>
        /// <returns>O cadastro do produto criado.</returns>
        /// <response code="201">Produto criado.</response>
        /// <response code="400">Informações fornecidas inválidas.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost("criar")]
        [Authorize(Roles = $"{Roles.Admin},{Roles.Default}")]
        public async Task<IActionResult> CriarAsync(ProdutoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var novoProduto = await _produtoService.CriarAsync(dto);

            return CreatedAtAction(nameof(GetPorIdAsync),
                new { id = novoProduto.Id },
                novoProduto);
        }

        /// <summary>
        /// Atualiza o cadastro de um produto.
        /// </summary>
        /// <param name="id">ID única do Produto.</param>
        /// <param name="dto">Campos: Nome do Produto, Preço e Email do fornecedor.</param>
        /// <returns>O cadastro do produto criado.</returns>
        /// <response code="204">Ok, produto atualizado.</response>
        /// <response code="400">Informações fornecidas inválidas.</response>
        /// <response code="404">Produto não encontrado.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [HttpPut("atualizar")]
        [Authorize(Roles = $"{Roles.Admin},{Roles.Default}")]
        public async Task<IActionResult> AtualizarAsync(int id, ProdutoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var resultado = await _produtoService.AtualizarAsync(id, dto);

            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta um produto do banco de dados.
        /// </summary>
        /// <param name="id">ID única do Produto.</param>
        /// <response code="204">Ok, produto deletado.</response>
        /// <response code="404">Produto não encontrado.</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [HttpDelete("deletar/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var resultado = await _produtoService.DeletarAsync(id);

            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Pesquisa produtos que estejam no range de preço mínimo e preço máximo definidos.
        /// </summary>
        /// <param name="precoMin">Preço mínimo.</param>
        /// <param name="precoMax">Preço máximo.</param>
        /// <returns>Lista com todos os produtos no range de preço, ou lista vazia.</returns>
        /// <response code="200">Ok, retorna lista de produtos.</response>
        /// <response code="400">Informações fornecidas inválidas.</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpGet("buscar")]
        [Authorize(Roles = $"{Roles.Admin},{Roles.Default}")]
        public async Task<IActionResult> PesquisaRangePrecoAsync(
            [FromQuery] double? precoMin,
            [FromQuery] double? precoMax)
        {
            var resultado = await _produtoService.PesquisaRangePrecoAsync(precoMin, precoMax);

            if (resultado == null)
            {
                return BadRequest();
            }

            return Ok(resultado);
        }

        // Exercícios Aula 01
        //string[] produtos = ["Produto 0", "Produto 1", "Produto 2", "Produto 3", "Produto 4"];

        //[HttpGet("listar")]
        //public IActionResult ListarProdutos()
        //{
        //    return Ok(produtos);
        //}

        //[HttpGet]
        //public IActionResult ConsultaProduto(int id)
        //{
        //    string produtoSelecionado;

        //    try
        //    {
        //        produtoSelecionado = produtos[id];
        //    }
        //    catch (IndexOutOfRangeException)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(produtoSelecionado);
        //}
    }
}