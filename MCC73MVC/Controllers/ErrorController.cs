using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Unauthorized()
        {
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
