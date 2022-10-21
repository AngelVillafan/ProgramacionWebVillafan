using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Act4_Pixar.Models;
using U2Act4_Pixar.Models.ViewModels;

namespace U2Act4_Pixar.Controllers
{
    public class HomeController : Controller
    {
        PixarContext contexto = new PixarContext();

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Seccion = "Inicio";

            return View();
        }

        [Route("Peliculas")]
        public IActionResult Peliculas()
        {
            var Peliculas = contexto.Pelicula.OrderBy(x => x.Nombre).Select(x => new PeliculasViewModel
            {
                Nombre = x.Nombre,
                Id = x.Id
            });
            return View(Peliculas);
        }

        [Route("Cortos")]
        public IActionResult Cortos()
        {
            var categorias = contexto.Categoria.Include(x => x.Cortometraje).OrderBy(x => x.Nombre);
            return View(categorias);
        }

        [Route("Peliculas/{id}")]
        public IActionResult Pelicula(string id)
        {
            var pelicula = contexto.Pelicula.Include(x=>x.Apariciones).ThenInclude(x=>x.IdPersonajeNavigation).FirstOrDefault(x => x.Nombre == id.Replace("_"," "));
            if (pelicula == null)
                return RedirectToAction("Peliculas");

            return View(pelicula);
        }

        [Route("Cortos/{nombre}")]
        public IActionResult Corto(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return RedirectToAction("Cortos");

            nombre = nombre.Replace("_", " ");
            var cortos = contexto.Cortometraje.FirstOrDefault(x => x.Nombre == nombre);
            if (cortos == null)
                return RedirectToAction("Cortos");
            return View(cortos);
        }
    }
}
