using EnergyQuiz.Models;
using EnergyQuiz.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnergyQuiz.Controllers
{
    public class HomeController : Controller
    {
        public const string SessionName = "_Nome";
        public const string SessionKey = "_isAuth";


        private readonly ILogger<HomeController> _logger;
        private readonly IUserAuth userAuth;

        public HomeController(ILogger<HomeController> logger, IUserAuth repository)
        {
            userAuth = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
