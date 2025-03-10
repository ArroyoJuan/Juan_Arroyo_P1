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
        public IActionResult RegistrarPaciente()
        {
            // Lógica para mostrar el formulario de registro de pacientes
            return View();
        }
        public IActionResult Index()
        {
            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("yyyy-MM-dd");
            List<Datos> citas = _datos.cargarCitas(fechaFormateada);
            ViewBag.Citas = citas;
            /*DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            List<Datos> citas = _datos.cargarCitas(fechaFormateada);
            for (int i = 0; i < citas.Count; i++)
            {
                TempData["IDCitaSetTable"] = citas[i].id_citaC;
            }*/

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
                var paciente = _datos.BuscarPaciente(datos.cedulaP);

                if (paciente == null)
                {
                    TempData["SuccessMessage"] = "Error: El paciente no fue encontrado.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["SuccessMessage"] = "Paciente encontrado.";
                    TempData["IdPaciente"] = Convert.ToString(paciente.id_pacienteP);
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
        public IActionResult Registrar(Datos datos)
        {
            try
            {
                _datos.RegistrarPaciente(datos);
                TempData["SuccessMessage"] = "El paciente se guardo con exito.";
                return RedirectToAction("RegistrarPaciente");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error: " + ex.Message;
                return RedirectToAction("RegistrarPaciente");
            }
            return RedirectToAction("RegistrarPaciente");
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
