using Microsoft.AspNetCore.Mvc;

namespace BikeTourPlaner.Controllers
{
    public class ResponseController : Controller
    {
        public IActionResult AllGood()
        {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            ViewData["_DataManipResponse"] = HttpContext.Session.GetString("_DataManipResponse");
            return View();
        }
    }
}
