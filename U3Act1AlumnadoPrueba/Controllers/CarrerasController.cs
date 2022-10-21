using Microsoft.AspNetCore.Mvc;
using U3Act1AlumnadoPrueba.Models;

namespace U3Act1AlumnadoPrueba.Controllers
{
    public class CarrerasController : Controller
    {
        AlumnadoContext contexto = new AlumnadoContext();

        public IActionResult Index()
        {
            var carreras = contexto.Carrera.OrderBy(x => x.Nombre);
            return View(carreras);
        }

        public IActionResult Agregar()
        {
            return View();
        }
    }
}
