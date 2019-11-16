using Entidad;
using Entidad.ViewsModels;
using Negocio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Biblioteca_ASP.Controllers
{
    public class LibrosController : Controller
    {
        public ActionResult Index()
        {
            var ListaLibros = N_Libro.ListaLibros();
            return View(ListaLibros);
        }
        public ActionResult Crear()
        {
            var ListaAutores = N_Autor.ListarAutores();
            //ViewBag.Autores = ListaAutores.Select(x => new SelectListItem () { Value = x.IdAutor.ToString(), Text =  x.Nombre }).ToList();
            ViewBag.Autores = ListaAutores;
            return View();
        }       
             

        public JsonResult CrearLibro(VM_CrearLibro Libro)
        {
            if (ModelState.IsValid)
            {
                N_Libro.GuardarLibro(Libro);
            }
            return Json(Libro, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(int id)
        {
            var lib = N_Libro.Get_Libro(id);
            return View(lib);
        }
        [HttpPost]
        public ActionResult Editar(Libro libro)
        {
            N_Libro.EditarLibro(libro);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
            var lib = N_Libro.Get_Libro(id);
            return View(lib);
        }
        [HttpPost]
        public ActionResult Eliminar(Libro libro)
        {
            N_Libro.EliminarLibro(libro);
            return RedirectToAction("Index");
        }
        public ActionResult MostrarLibro(int id)
        {
            var lib = N_Libro.Get_Libro(id);
            IEnumerable<Autor> ListaAutores = N_Libro.ListarAutoresLibro(id);
            ViewBag.Autores = ListaAutores;
            return View(lib);
        }
    }
}