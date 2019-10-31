using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Datos.IRepositorio;
using Entidad;

namespace Datos.Datos.Repositorio
{
    public class AutorRepository : Repositorio<Autor>, IAutorRepository
    {
        public AutorRepository(DbContext Context) : base(Context)
        {

        }

        public DbContext BibliotecaDbContext
        {
            get { return _Context as DbContext; }
        }
             
    } 
}
