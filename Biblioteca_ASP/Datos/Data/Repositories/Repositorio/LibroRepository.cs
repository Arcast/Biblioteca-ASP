using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Data.Repositories.IRepositorio;
using Datos.Datos.Repositorio;
using Entidad;
using Entidad.ViewsModels;

namespace Datos.Data.Repositories.Repositorio
{
    public class LibroRepository : Repositorio<Libro>, ILibroRepository
    {
       
        public LibroRepository(DbContext Context) : base(Context)
            {
            }

        public DbContext BibliotecaContext
        {
            get { return _Context as DbContext; }
        }
             
    }
}
