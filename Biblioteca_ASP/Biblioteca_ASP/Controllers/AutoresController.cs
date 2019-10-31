using System;
using System.Web.Mvc;
using Entidad;
using Entidad.FluentValidation;
using Negocio;



namespace Biblioteca_ASP.Controllers
{
    public class AutoresController : Controller
    {
        // GET: Autores
        public ActionResult Index()
        {
            var ListAutores = N_Autor.ListarAutores();
            return View(ListAutores);
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Autor autor)
        {

            if (ModelState.IsValid)
            {
                N_Autor.GuardarAutor(autor);
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Ocurrio un error al guardar el autor");
            return View(autor);

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