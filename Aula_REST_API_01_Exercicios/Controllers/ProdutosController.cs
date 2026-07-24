using Aula_REST_API_01_Exercicios.Data;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listarTodos")]
        public async Task<IActionResult> GetTodos()
        {
            List<Produto> produtosCadastrados = await _context.Produtos.ToListAsync();
            return Ok(produtosCadastrados);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            Produto produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar(ProdutoDto dto)
        {
            Produto novoProduto = new Produto
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                EmailFornecedor = dto.EmailFornecedor
            };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Produtos.Add(novoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPorId),
                new { id = novoProduto.Id },
                novoProduto);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar(int id, ProdutoDto dto)
        {
            Produto produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            produto.EmailFornecedor = dto.EmailFornecedor;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            Produto produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> PesquisaRangePreco(
            [FromQuery] decimal? precoMin,
            [FromQuery] decimal? precoMax)
        {
            if (precoMax < precoMin)
            {
                return BadRequest();
            }

            var consulta = _context.Produtos.AsQueryable();

            if (precoMin != null)
                consulta = consulta.Where(p => p.Preco >= precoMin.Value);

            if (precoMax != null)
                consulta = consulta.Where(p => p.Preco <= precoMax.Value);

            var produtosCadastrados = await consulta.ToListAsync();
            return Ok(produtosCadastrados);
        }

        // Exercícios Aula 01
        string[] produtos = ["Produto 0", "Produto 1", "Produto 2", "Produto 3", "Produto 4"];

        [HttpGet("listar")]
        public IActionResult ListarProdutos()
        {
            return Ok(produtos);
        }

        [HttpGet]
        public IActionResult ConsultaProduto(int id)
        {
            string produtoSelecionado;

            try
            {
                produtoSelecionado = produtos[id];
            }
            catch (IndexOutOfRangeException)
            {
                return NotFound();
            }

            return Ok(produtoSelecionado);
        }
    }
}