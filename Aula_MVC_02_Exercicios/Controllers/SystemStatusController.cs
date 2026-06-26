/* MINI API STATUS - Crie um Controller de monitoramento que simula um endpoint de status de sistema
   - Crie StatusController com [Route("status")]
   - Crie GET /status que retorna Json com: {sistema: "online", hora: datetime.now }
   - Crie GET /status/{servico} que recebe o nome de um serviço (ex: banco, api, cache)
   - Para serviços conhecidos (lista fixa), retorne {servico} = "operacional"
   - Para serviços desconhecidos, retorne NotFound() com uma mensagem customizada */

using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_02_Exercicios.Controllers
{
    [Route("status")]
    public class SystemStatusController : Controller
    {
        List<string> servicos = ["API", "NotaFiscal", "Estoque", "Integração"];
        
        [HttpGet]
        public IActionResult Index()
        {
            return Json("sistema: online, hora: " + DateTime.Now);
        }

        [HttpGet("{nomeservico}")]
        public IActionResult Servico(string nomeServico)
        {
            if (servicos.Any(s => s.ToUpper() == nomeServico.ToUpper()))
            {
                return Json($"servico: {nomeServico}, operacional");
            }
            return NotFound("Serviço não cadastrado, verifique a escrita.");
        }
    }
}