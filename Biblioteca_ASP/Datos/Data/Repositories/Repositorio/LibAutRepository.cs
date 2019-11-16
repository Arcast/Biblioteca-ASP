using Datos.Data.Repositories.IRepositorio;
using Datos.Datos.Repositorio;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Data.Repositories.Repositorio
{
    public class LibAutRepository : Repositorio<LibAut>, ILibAutRepository
    {
        public LibAutRepository(DbContext context) : base(context)
        {
        }
        public DbContext BibliotecaContext
        {
            get { return _Context as DbContext; }
        }
    }
}
