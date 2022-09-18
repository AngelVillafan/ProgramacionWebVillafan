using Microsoft.AspNetCore.Mvc;

namespace PruebaControlador.Controllers
{
    public class TablasController : Controller
    {
        public IActionResult Index(int id)
        {
            return View(id);
        }
    }
}
