using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto_Biblioteca.WEB.Models;

namespace Projeto_Biblioteca.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Página inicial
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Funcionarios()
        {
            return RedirectToAction("Index", "Funcionarios");
        }

        public IActionResult Produtos()
        {
            return RedirectToAction("Index", "Produtos");
        }

        public IActionResult Usuarios()
        {
            return RedirectToAction("Index", "Usuarios");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
