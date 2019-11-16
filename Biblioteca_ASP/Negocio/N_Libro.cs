using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Entidad.ViewsModels;
using Datos.Datos.IBase;

namespace Negocio
{
    public class N_Libro 
    {
        private static D_Libro daoLibro = new D_Libro(new BibliotecaDbContext());

        public static List<Libro> ListaLibros()
        {
            return daoLibro.ListaLibros();
        }

        public static void GuardarLibro(VM_CrearLibro lib)
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
                Libro l = new Libro();
                l.Titulo = lib.Titulo;
                l.Editorial = lib.Editorial;
                l.Area = lib.Area;

                foreach (var aut in lib.IdAutor)
                {
                    LibAut la = new LibAut
                    {
                        IdAutor = aut
                    };

                    l.libAuts.Add(la);
                }
                unit.Libro.AddOrUpdate(l);
                unit.Complete();
            }
        }
        public static void EditarLibro(Libro libro)
        {
            daoLibro.EditarLibro(libro);
        }
        public static void EliminarLibro(Libro libro)
        {
            daoLibro.EliminarLibro(libro);
        }
        public static Libro Get_Libro(int id)
        {
            return daoLibro.Get_Libro(id);
        }
        public static IEnumerable<Autor> ListarAutoresLibro(int id)
        {
            return daoLibro.ListarAutoresLibro(id);
        }

    }
}
