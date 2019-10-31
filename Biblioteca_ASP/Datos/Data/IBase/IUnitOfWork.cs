using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Data.Repositories.IRepositorio;
using Datos.Datos.IRepositorio;
using Datos.Datos.Repositories.IRepositorio;
using Entidad;

namespace Datos.Datos.IBase
{
    public interface IUnitOfWork : IDisposable
    {
        IAutorRepository Autor { get; }
        IEstudianteRepository Estudiante { get; }
        ILibroRepository Libro { get; }
        int Complete();
    }
}

