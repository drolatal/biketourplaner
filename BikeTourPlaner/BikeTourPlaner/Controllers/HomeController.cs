using BikeTourPlaner.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BikeTourPlaner.Controllers
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
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}