using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entidad.ViewsModels.VM_Estudiantes;
using Entidad;

namespace Biblioteca_ASP.Controllers
{
    public class EstudiantesController : Controller
    {
        // GET: Estudiantes
        public ActionResult Index()
        {
            var Estudiantes = N_Estudiante.MostrarEstudiantes();
            return View(Estudiantes);
        }

        public PartialViewResult Crear()
        {
            return PartialView("~/Views/Estudiantes/Crear.cshtml");
        }

        public JsonResult GuardarEstudiante(VM_GuardarEstudiante estud)
        {
            if (ModelState.IsValid)
            {
                N_Estudiante.GuardarEstudiante(estud);
            }
            return Json(estud, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Editar(int id)
        {
            var estudiante = N_Estudiante.BuscarEstudiante(id);
            return PartialView("~/Views/Estudiantes/Editar.cshtml",estudiante);
        }

        public JsonResult EditarEstudiante(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                N_Estudiante.EditarEstudiante(estudiante);
            }
            return Json(estudiante, JsonRequestBehavior.AllowGet);
        }

    }
}