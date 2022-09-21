using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Act2.Models;

namespace Ejercicio2.Controllers
{
    public class HomeController : Controller
    {

        PresidentesContext contenedor = new PresidentesContext();

        public IActionResult Index()
        {
            var lista = contenedor.Presidente.OrderBy(x => x.InicioGobierno);
            return View(lista);
        }
        public IActionResult Biografia(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("Index");
            }
            id = id.Replace("-", " ");

            //Carga explicita
            var presidente = contenedor.Presidente.Include(x=>x.IdPartidoPoliticoNavigation).Include(x=>x.IdEstadoRepublicaNavigation).FirstOrDefault(x=>x.Nombre == id);

            if (presidente != null)
            {
                return View(presidente);
            }
            return RedirectToAction("Index");
        }
    }
}
