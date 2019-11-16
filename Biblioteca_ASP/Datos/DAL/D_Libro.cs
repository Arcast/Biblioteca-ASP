using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Data.Repositories.IRepositorio;
using Datos.Datos.IBase;
using Datos.Datos.Repositorio;
using Entidad;
using Entidad.ViewsModels;

namespace Datos
{
    public class D_Libro : Repositorio<Libro>, ILibroRepository
    {
        public D_Libro(BibliotecaDbContext context) : base(context)
        {

        }

        public List<Libro> ListaLibros()
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
                return unit.Libro.ListAll().ToList();
            }
        }
        public void GuardarLibro(VM_CrearLibro lib)
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
                Libro l = new Libro();
                l.Titulo = lib.Titulo;
                l.Editorial = lib.Editorial;
                l.Area = lib.Area;
                unit.Libro.AddOrUpdate(l);
                unit.Complete();

                foreach (var aut in lib.IdAutor)
                {
                    LibAut la = new LibAut
                    {
                        IdLibro = l.IdLibro,
                        IdAutor = aut
                    };

                    unit.LibAut.AddOrUpdate(la);
                }

                unit.Complete();
            }
        }
        public void EditarLibro(Libro libro)
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
                var l = unit.Libro.GetByID(libro.IdLibro);
                l.Titulo = libro.Titulo;
                l.Editorial = libro.Editorial;
                l.Area = libro.Area;
                unit.Libro.AddOrUpdate(l);
                unit.Complete();
            }
        }
        public void EliminarLibro(Libro libro)
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
                unit.Libro.Remove(libro.IdLibro);
            }
        }
        public Libro Get_Libro(int id)
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
                return unit.Libro.GetByID(id);
            }
        }
              

        public IEnumerable<Autor> ListarAutoresLibro(int id)
        {
            using (var db = new BibliotecaDbContext())
            {
                return (from a in db.LibAuts join aut in db.Autors on a.IdAutor equals aut.IdAutor where a.IdLibro == id select aut).ToList();
            }
        }
    }
}
