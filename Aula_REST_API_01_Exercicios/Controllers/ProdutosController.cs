using Aula_REST_API_01_Exercicios.Models;
using Aula_REST_API_01_Exercicios.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aula_REST_API_01_Exercicios.Interfaces;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("listarTodos")]
        [Authorize(Roles = $"{Roles.Admin},{Roles.Default}")]
        public async Task<IActionResult> GetTodosAsync()
        {
            List<Produto> produtosCadastrados = await _produtoService.GetTodosAsync();
            return Ok(produtosCadastrados);
        }

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

        [HttpPut("atualizar")]
        [Authorize]
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

        [HttpGet("buscar")]
        [Authorize(Roles = $"{Roles.Admin},{Roles.Default}")]
        public async Task<IActionResult> PesquisaRangePrecoAsync(
            [FromQuery] decimal? precoMin,
            [FromQuery] decimal? precoMax)
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