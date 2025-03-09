using Juan_Arroyo_P1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Juan_Arroyo_P1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccesoDatos _datos;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AccesoDatos datos, ILogger<HomeController> logger)
        {
            _datos = datos;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agendar(Datos datos)
        {
            try
            {
                _datos.IngresarCita(datos);
                TempData["SuccessMessage"] = "Tu cita se guardo con exito.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error: " + ex.Message;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult buscar(Datos datos)
        {
            try
            {
                if (_datos.BuscarPaciente(datos) == "Paciente encontrado.")
                {
                    TempData["SuccessMessage"] = "Paciente encontrado.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Error: El paciente no existe.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error: " + ex.Message;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
