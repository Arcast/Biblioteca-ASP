using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos.Datos.IRepositorio;
using Datos.Datos.Repositorio;
using Datos.Datos.IBase;

namespace Datos
{
    public class D_Autor : Repositorio<Autor>, IAutorRepository
    {
        public D_Autor(BibliotecaDbContext Context) : base(Context)
        {
        }

        public List<Autor> ListarAutores()
        {
            using (var unitOfWork = new UnitOfWork(new BibliotecaDbContext()))
            {
               return unitOfWork.Autor.FindBy(x => x.Estatus == true).ToList(); 
            }   
        }

        public void GuardarAutor(Autor autor)
        {
            using (var unitOfWork = new UnitOfWork(new BibliotecaDbContext()))
            {
                unitOfWork.Autor.AddOrUpdate(autor);
                unitOfWork.Complete();
            }
        }

        public Autor Get_Autor(int id)
        {
            using (var unitOfWork = new UnitOfWork(new BibliotecaDbContext()))
            {
                return unitOfWork.Autor.GetByID(id);
            }
        }

        public void EditarAutor(Autor autor)
        {
            using (var unitOfWork = new UnitOfWork(new BibliotecaDbContext()))
            {
                var aut = unitOfWork.Autor.GetByID(autor.IdAutor);
                aut.Nombre = autor.Nombre;
                aut.Nacionalidad = autor.Nacionalidad;
                unitOfWork.Autor.AddOrUpdate(aut);
                unitOfWork.Complete();
            }
        }
        public void EliminarAutor(Autor autor)
        {
            using (var unitOfWork = new UnitOfWork(new BibliotecaDbContext()))
            {
                var aut = unitOfWork.Autor.GetByID(autor.IdAutor);
                aut.Estatus = false;
                unitOfWork.Autor.AddOrUpdate(aut);
                unitOfWork.Complete();
            }
        }

    }
}
