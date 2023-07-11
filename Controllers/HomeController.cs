using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TPElecciones.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var partidos = BD.ListarPartidos();
            ViewBag.Partidos = partidos;
            return View();
        }

        public IActionResult VerDetallePartido(int idPartido)
        {
            var partido = BD.VerInfoPartido(idPartido);
            var candidatos = BD.ListarCandidatos(idPartido);
            ViewBag.Partido = partido;
            ViewBag.Candidatos = candidatos;
            return View();
        }

        public IActionResult VerDetalleCandidato(int idCandidato)
        {
            var candidato = BD.VerInfoCandidato(idCandidato);
            ViewBag.Candidato = candidato;
            return View();
        }

        public IActionResult AgregarCandidato(int idPartido)
        {
            ViewBag.IdPartido = idPartido;
            return View();
        }

        [HttpPost]
        public IActionResult GuardarCandidato(Candidato candidato)
        {
            BD.AgregarCandidato(candidato);
            return RedirectToAction("VerDetallePartido", new { idPartido = candidato.IdPartido });
        }

        public IActionResult EliminarCandidato(int idCandidato, int idPartido)
        {
            BD.EliminarCandidato(idCandidato);
            return RedirectToAction("VerDetallePartido", new { idPartido = idPartido });
        }

        public IActionResult Elecciones()
        {
            return View();
        }

        public IActionResult Creditos()
        {
            return View();
        }

    }
}
