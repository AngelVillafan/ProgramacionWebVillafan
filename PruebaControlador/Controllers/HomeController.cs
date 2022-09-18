using Microsoft.AspNetCore.Mvc;

namespace PruebaControlador.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Pagina2()
        {
            return View();
        }

        public string Saludame(string nombre, string apellido)//QueryString
        {
            return "Hola "+ nombre +" "+ apellido+ "!!!";
        }
        public int Suma(int x, int y)
        {
            return x + y;
        }
    }
}
