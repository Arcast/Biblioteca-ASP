using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Datos.Repositories.IRepositorio;
using Datos.Datos.Repositorio;
using Entidad;

namespace Datos.Datos.Repositories.Repositorio
{
   public class EstudianteRepository : Repositorio<Estudiante> , IEstudianteRepository
    {
        public EstudianteRepository(DbContext Context) : base(Context)
        {

        }

        public DbContext BibliotecaDbContext
        {
            get { return _Context as DbContext; }
        }

    }

}
