using Microsoft.AspNetCore.Mvc;

namespace U3Act1AlumnadoPrueba.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
