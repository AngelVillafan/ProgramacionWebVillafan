using Microsoft.AspNetCore.Mvc;
using U1_Tarea2.Models;

namespace U1_Tarea2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(Promedio promedio)
        {
            if (!string.IsNullOrWhiteSpace(promedio.Materia1.ToString()) || !string.IsNullOrWhiteSpace(promedio.Materia2.ToString()) || !string.IsNullOrWhiteSpace(promedio.Materia3.ToString()))
            {
                promedio.MediaAritmetica = (promedio.Materia1 + promedio.Materia2 + promedio.Materia3) / 3;
            }
            return View(promedio);
        }
    }
}
