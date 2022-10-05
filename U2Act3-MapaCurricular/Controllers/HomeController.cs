using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Act3_MapaCurricular.Models;
using U2Act3_MapaCurricular.Models.ViewModels;

namespace U2Act3_MapaCurricular.Controllers
{
    public class HomeController : Controller
    {
        Mapa_CurricularContext contenedor = new();

        [Route("/")]
        public IActionResult Index()
        {
            var carreras = contenedor.Carreras.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            {
                Nombre = x.Nombre,
                Plan = x.Plan
            });
            return View(carreras);
        }

        [Route("{id}")]
        public IActionResult Datos(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("Index");
            }
            id = id.Replace("-", " ");
            var carrera = contenedor.Carreras.FirstOrDefault(x => x.Nombre == id);
            if (carrera == null)
            {
                return RedirectToAction("Index");

            }
            return View(carrera);

        }

        [Route("{id}/Reticula")]
        public IActionResult Reticula(string id)
        {
            if (string.IsNullOrWhiteSpace(id))//Si no me dan el nombre de la carrera
            {
                return RedirectToAction("Index"); //Los mando a index
            }
            id = id.Replace("-"," ");
            var carrera = contenedor.Carreras.Include(x => x.Materia).FirstOrDefault(x => x.Nombre == id);

            if (carrera == null)//Si la carrera no existe
            {
                return RedirectToAction("Index");//Lo mando a index
            }

            ReticulaViewModel vm = new();
            vm.Carrera = carrera.Nombre;
            vm.Plan = carrera.Plan;
            vm.CreditosTotales = carrera.Materia.Sum(x => x.Creditos);

            for (int i = 0; i < 9; i++)
            {
                vm.Semestres[i] = carrera.Materia.Where(x => x.Semestre == i + 1).ToList();
            }

            //vm.Semestres = Enumerable.Range(0, 10).Select(x => carrera.Materia.Where(y => y.Semestre == x + 1).ToList()).ToArray();


            return View(vm);
        }
    }
}
