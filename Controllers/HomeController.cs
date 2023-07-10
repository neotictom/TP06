using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP06.Models;

namespace TP06.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BD _bd;

        public HomeController(ILogger<HomeController> logger, BD bd)
        {
            _logger = logger;
            _bd = bd;
        }

        public IActionResult Index()
        {  
            ViewBag.ListaPartidos = _bd.ListarPartido(); 
            return View("Index");
        }

        public IActionResult VerDetallePartido(int idPartido)
        {
            ViewBag.InfoPartido = _bd.VerInfoPartido(idPartido);
            ViewBag.ListaCandidatos = _bd.ListarCandidatos(idPartido); 
            return View("VerDetallePartido");
        }

        public IActionResult VerDetalleCandidato(int idCandidato)
        {
            ViewBag.InfoCandidato = _bd.VerInfoCandidato(idCandidato); 
            return View("VerDetalleCandidato");
        }

        public IActionResult AgregarCandidato(int idPartido)
        {
            ViewBag.IdPartido = idPartido; // Agregar el IdPartido al ViewBag
            return View();
        }

        [HttpPost]
        public IActionResult GuardarCandidato(Candidato can)
        {
            _bd.GuardarCandidato(can); // Agregar el método GuardarCandidato() en la clase BD para guardar el candidato en la base de datos
            return RedirectToAction("VerDetallePartido", new { idPartido = can.IdPartido }); 
        }

        public IActionResult EliminarCandidato(int idCandidato, int idPartido)
        {
            _bd.EliminarCandidato(idCandidato); // Agregar el método EliminarCandidato() en la clase BD para eliminar el candidato de la base de datos
            return RedirectToAction("VerDetallePartido", new { idPartido }); 
        }
        public IActionResult Elecciones()
        {
            return View();
        }

        public IActionResult Creditos()
        {
            return View();
        }

        public IActionResult Privacy()
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

