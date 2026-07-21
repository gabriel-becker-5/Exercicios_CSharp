using Microsoft.AspNetCore.Mvc;

namespace Aula_REST_API_01_Exercicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
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