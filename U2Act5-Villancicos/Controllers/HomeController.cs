using Microsoft.AspNetCore.Mvc;
using U2Act5_Villancicos.Models;
using U2Act5_Villancicos.Models.ViewModels;

namespace U2Act5_Villancicos.Controllers
{
    public class HomeController : Controller
    {
        VillancicosContext context = new();

        public IActionResult Index()
        {
            var villancicos = context.Villancico.Select(x => new
            {
                Nombre = x.Nombre.Trim(),
                Informacion = x.Información,
            }).OrderBy(x=>x.Nombre);
            return View(villancicos);
        }

        public IActionResult Villancico(string id)
        {
            id = id.Replace("_", " ");
            var villancico = context.Villancico.Select(x=> new VillancicoViewModel
            {
                Nombre = x.Nombre,
                Compositor = x.Compositor,
                Año = x.Anyo,
                VideoUrl = x.VideoUrl
            }).FirstOrDefault(x => x.Nombre == id);
            if (villancico == null)
            {
                return RedirectToAction("Index");
            }
            return View(villancico);
        }

        public IActionResult VillancicoLetra()
        {
            return View();
        }
    }
}
