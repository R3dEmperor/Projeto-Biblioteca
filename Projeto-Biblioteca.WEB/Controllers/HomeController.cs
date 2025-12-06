//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using Projeto_Biblioteca.WEB.Models;

//namespace Projeto_Biblioteca.WEB.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}

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
            // Pode adicionar dados para a view se quiser futuramente
            return View();
        }

        // Página de privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // Página de erro
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

