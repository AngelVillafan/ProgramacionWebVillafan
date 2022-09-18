using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
