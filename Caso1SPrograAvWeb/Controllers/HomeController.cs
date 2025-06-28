using Caso1SPrograAvWeb.Data;
using Caso1SPrograAvWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Caso1SPrograAvWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMatriculaRepository _repo;

        public HomeController(IMatriculaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegistrarMatricula()
        {

            ViewBag.TiposCursos = await _repo.ObtenerTiposCursosAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarMatricula(MatriculaModel model)
        {
            if (!ModelState.IsValid)
                return View("RegistrarMatricula", model);

            // Validar existencia del tipo de curso (por ID)
            bool existeTipo = await _repo.TipoCursoExisteAsync(model.TipoCurso);
            if (!existeTipo)
            {
                ModelState.AddModelError("TipoCurso", "El tipo de curso no existe.");
                return View("RegistrarMatricula", model);
            }

            // Validar que el estudiante no tenga más de 2 matrículas
            int cantidad = await _repo.ContarMatriculasPorEstudianteAsync(model.NombreEstudiante!);
            if (cantidad >= 2)
            {
                ModelState.AddModelError("NombreEstudiante", "Este estudiante ya tiene 2 matrículas registradas.");
                return View("RegistrarMatricula", model);
            }

            // Intentar registrar
            bool exito = await _repo.RegistrarMatriculaAsync(model);
            if (!exito)
            {
                ModelState.AddModelError("", "No se pudo registrar la matrícula. Intente nuevamente.");
                return View("RegistrarMatricula", model);
            }

            TempData["Mensaje"] = "Matrícula registrada exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarMatriculas()
        {
            var resultados = await _repo.ObtenerConsultasAsync();
            return View(resultados); // Apunta a ConsultarMatriculas.cshtml
        }
    }
}