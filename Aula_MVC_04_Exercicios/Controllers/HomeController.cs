using Aula_MVC_04_Exercicios.Interfaces;
using Aula_MVC_04_Exercicios.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aula_MVC_04_Exercicios.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataHoraService _dataHoraService;

        public HomeController(ILogger<HomeController> logger, IDataHoraService datahoraservice)
        {
            _logger = logger;
            _dataHoraService = datahoraservice;
        }

        public IActionResult Index()
        {
            return View(_dataHoraService);
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
    }
}
