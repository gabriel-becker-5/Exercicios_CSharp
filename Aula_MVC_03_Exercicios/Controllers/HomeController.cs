using Aula_MVC_03_Exercicios.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aula_MVC_03_Exercicios.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Produto> produtos = new List<Produto>();
            Produto produto1 = new Produto("iPhone 128gb", 5999.90m, "Celular");
            Produto produto2 = new Produto("iPhone 256gb", 7999.90m, "Celular");
            Produto produto3 = new Produto("iPhone 518gb", 9999.90m, "Celular");
            Produto produto4 = new Produto("iPhone 1TB", 11999.90m, "Celular");
            Produto produto5 = new Produto("Samsung Galaxy M21S", 1000.99m, "Celular");
            produtos.Add(produto1);
            produtos.Add(produto2);
            produtos.Add(produto3);
            produtos.Add(produto4);
            produtos.Add(produto5);
            return View(produtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Saudacao(string nome)
        {
            ViewBag.Nome = nome;
            return View();
        }

        [HttpGet]
        public IActionResult Tarefas()
        {
            List<Tarefa> Tarefas = new List<Tarefa>();
            Tarefa tarefa1 = new Tarefa("Tomar Café", true);
            Tarefa tarefa2 = new Tarefa("Ir para o Trabalho", true);
            Tarefa tarefa3 = new Tarefa("Almoçar", false);
            Tarefa tarefa4 = new Tarefa("Ir para aula do Entra 21", false);
            Tarefas.Add(tarefa1);
            Tarefas.Add(tarefa2);
            Tarefas.Add(tarefa3);
            Tarefas.Add(tarefa4);
            return View(Tarefas);
        }

        [HttpGet("home/estoque")]
        public IActionResult Estoque(int quantidade)
        {
            ViewBag.Quantidade = quantidade;
            return View();
        }

        [HttpGet("home/catalogo")]
        public IActionResult Catalogo()
        {
            List<Produto> produtos = new List<Produto>();
            Produto produto1 = new Produto("iPhone 128gb", 5999.90m, "Celular");
            Produto produto2 = new Produto("iPhone 256gb", 7999.90m, "Celular");
            Produto produto3 = new Produto("iPhone 518gb", 9999.90m, "Celular");
            Produto produto4 = new Produto("iPhone 1TB", 11999.90m, "Celular");
            Produto produto5 = new Produto("Samsung Galaxy M21S", 1000.99m, "Celular");
            Produto produto6 = new Produto("Airfryer 220v", 499.90m, "Eletrônicos");
            produtos.Add(produto1);
            produtos.Add(produto2);
            produtos.Add(produto3);
            produtos.Add(produto4);
            produtos.Add(produto5);
            produtos.Add(produto6);
            return View(produtos);
        }
    }
}