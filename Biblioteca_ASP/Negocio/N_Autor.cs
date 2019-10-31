using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Negocio
{
   public class N_Autor
    {
        private static D_Autor daoAutor = new D_Autor(new BibliotecaDbContext());
        public static List<Autor> ListarAutores()
        {
            return daoAutor.ListarAutores();
        }
        public static void GuardarAutor(Autor autor)
        {
            daoAutor.GuardarAutor(autor);
        }
        public static Autor Get_Autor(int id)
        {
            return daoAutor.Get_Autor(id);
        }
         public static void EditarAutor(Autor autor)
        {
            daoAutor.EditarAutor(autor);
        }
        public static void EliminarAutor(Autor autor)
        {
            daoAutor.EliminarAutor(autor);
        }

    }
}
