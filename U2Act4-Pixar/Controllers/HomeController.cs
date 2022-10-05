using Microsoft.AspNetCore.Mvc;

namespace U2Act4_Pixar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Peliculas()
        {
            return View();
        }

    }
}
