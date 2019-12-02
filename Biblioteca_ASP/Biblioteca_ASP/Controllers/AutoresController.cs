using System;
using System.Web.Mvc;
using System.Web.Services;
using Entidad;
using Entidad.FluentValidation;
using Entidad.ViewsModels.Vm_Autor;
using Negocio;



namespace Biblioteca_ASP.Controllers
{
    public class AutoresController : Controller
    {
        // GET: Autores
        public ActionResult Index()
        {          
            return View();
        }       
       
        public PartialViewResult PV_Index()
        {
            var ListAutores = N_Autor.ListarAutores();
            return PartialView("~/Views/PartialView/Autores/PV_IndexAutor.cshtml", ListAutores);
        }

        public PartialViewResult CrearAutor()
        {
            return PartialView("~/Views/Autores/Crear.cshtml");
        }              
               
        public JsonResult Crear(VM_CrearAutor autor)
        {
            if (ModelState.IsValid)
            {
                var aut = new Autor();
                aut.Nombre = autor.Nombre;
                aut.Nacionalidad = autor.Nacionalidad;
                N_Autor.GuardarAutor(aut);                
            }
            return Json(autor, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult MostrarAutor(int id)
        {
            var aut = N_Autor.Get_Autor(id);
            return PartialView("~/Views/Autores/MostrarAutor.cshtml", aut);
        }

        public PartialViewResult EditarAutor(int id)
        {
            var aut = N_Autor.Get_Autor(id);
            return PartialView("~/Views/Autores/EditarAutor.cshtml", aut);
        }
        [HttpPost]
        public ActionResult EditarAutor(Autor autor)
        {           
                if (ModelState.IsValid)
                {
                    N_Autor.EditarAutor(autor);
                    return RedirectToAction("Index");
                }
            return RedirectToAction("Error");
        }
        public PartialViewResult EliminarAutor(int id)
        {
            var aut = N_Autor.Get_Autor(id);
            return PartialView("~/Views/Autores/EliminarAutor.cshtml", aut);
        }
               
        public JsonResult Eliminar(int Id)
        {
          
                var aut = N_Autor.Get_Autor(Id);
                N_Autor.EliminarAutor(aut);

            return Json(Id, JsonRequestBehavior.AllowGet);
          
        }

    }
}