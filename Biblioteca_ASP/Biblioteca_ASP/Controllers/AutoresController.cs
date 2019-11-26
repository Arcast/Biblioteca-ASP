using System;
using System.Web.Mvc;
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
        public ActionResult GetAutor(int id)
        {
            var autor = N_Autor.Get_Autor(id);
            return View(autor);
        }

        public ActionResult EditarAutor(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Error");
            }
            var aut = N_Autor.Get_Autor(id);
            return View(aut);
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
        public ActionResult EliminarAutor(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            var aut = N_Autor.Get_Autor(id.Value);
            return View(aut);
        }
        [HttpPost]
        public ActionResult EliminarAutor(int Id)
        {
            try
            {
                var aut = N_Autor.Get_Autor(Id);
                N_Autor.EliminarAutor(aut);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                var aut = N_Autor.Get_Autor(Id);
                return View(aut);
            }
               
            
          
        }

    }
}