using Microsoft.AspNetCore.Mvc;
using PersonalPortafolio.Models;
using PersonalPortafolio.servicios;
using System.Diagnostics;

namespace PersonalPortafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos _repProyectos;
        private readonly ISevicioEmail _servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repProyectos,ISevicioEmail servicioEmail)
        {
            _logger = logger;
            _repProyectos = repProyectos;
            _servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            
            var proyectos = _repProyectos.GetProyecto().Take(3).ToList();
            var modelo = new HomeIndexViewModel()
            {
                ProyectoDTOs = proyectos
            };

            //ViewBag.Name ="Elvis Hernández";
            return View(modelo);
        }

        

       public IActionResult ProyectoView()
        {
            var proyectos = _repProyectos.GetProyecto();
            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(ContactoDTO contactoDto)
        {
            _servicioEmail.Enviar(contactoDto);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
