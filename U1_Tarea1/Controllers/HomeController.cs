using Microsoft.AspNetCore.Mvc;
using U1_Tarea1.Models;

namespace U1_Tarea1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MiPerfil(Alumno alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Nombre) || string.IsNullOrWhiteSpace(alumno.NombreMateria) || string.IsNullOrWhiteSpace(alumno.Periodo))
            {
                return RedirectToAction("Index");
            }
            return View(alumno);
        }
    }
}
