/* EX 3 - Crie um Controller que retorna uma lista de produtos fixos em formato JSON
   - Crie ProdutosController com a Action Index()
   - Dentro da Action, crie uma List<string> com 5 nomes de produtos
   - Retorna a lista usando Json(lista)
   - Acesse /Produtos e observe o formato JSON retornado no navegador 
    
   EX 4 - Implemente uma Action que busca um produto específico por posição na lista
   - No mesmo ProdutosController, crie Detalhes(int id) com [HttpGet("{id}")]
   - Use a mesma lista de produtos do EX 3
   - Se o id for válido, retorne o nome do produto com Content()
   - Se o id estiver fora do intervalo, retorne NotFound()
   - Teste com IDs válidos e inválidos */

using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_02_Exercicios.Controllers
{
    public class ProdutosController : Controller
    {
        List<string> produtos = ["produto 1", "produto 2", "produto 3", "produto 4", "produto 5"];

        [HttpGet]
        public IActionResult Index()
        {
            return Json(produtos);
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            if (id >= 0 && id < produtos.Count())
            {
                return Content(produtos[id]);
            }
            return NotFound();
        }
    }
}