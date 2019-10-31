using System;
using Datos.Datos.IRepositorio;
using Datos.Datos.Repositorio;
using Datos.Datos.Repositories.IRepositorio;
using Datos.Datos.Repositories.Repositorio;
using System.Data.Entity;
using Entidad;
using Datos.Data.Repositories.Repositorio;
using Datos.Data.Repositories.IRepositorio;

namespace Datos.Datos.IBase
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _Context;
        public UnitOfWork(DbContext Context)
        {
            _Context = Context;
            Autor = new AutorRepository(_Context);
            Estudiante = new EstudianteRepository(_Context);
            Libro = new LibroRepository(_Context);
        }
        public IAutorRepository Autor { get; private set; }

        public IEstudianteRepository Estudiante { get; private set; }

        public ILibroRepository Libro { get; private set; }

        public int Complete()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
             
    }  
}
