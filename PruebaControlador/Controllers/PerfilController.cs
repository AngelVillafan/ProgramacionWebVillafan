using Microsoft.AspNetCore.Mvc;
using PruebaControlador.Models;

namespace PruebaControlador.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Datos(PerfilViewModel datos)
        {
            if (string.IsNullOrWhiteSpace(datos.Nombre))
            {
                return RedirectToAction("Index");
            }
            return View(datos);
        }



    }
}
