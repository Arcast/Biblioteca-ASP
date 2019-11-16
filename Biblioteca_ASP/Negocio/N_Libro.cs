using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Entidad.ViewsModels;

namespace Negocio
{
    public class N_Libro 
    {
        private static D_Libro daoLibro = new D_Libro(new BibliotecaDbContext());

        public static List<Libro> ListaLibros()
        {
            return daoLibro.ListaLibros();
        }

        public static void GuardarLibro(VM_CrearLibro libro)
        {
            daoLibro.GuardarLibro(libro);
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
