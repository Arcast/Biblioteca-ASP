using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Datos.Datos.Repositorio
{
    public class Repositorio<T> : IRepository<T> where T : class
    {
        internal DbContext _Context;
        internal DbSet<T> _DbSet;

        public Repositorio(DbContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<T>();
        }

        public void AddOrUpdate(T Entidad)
        {
            _DbSet.AddOrUpdate(Entidad);
        } 

        public void AddRange(IEnumerable<T> Entity)
        {
            _DbSet.AddRange(Entity);
        }

        public T GetByID(int id)
        {
           return _DbSet.Find(id);
        }

       
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
          return _DbSet.Where(predicate);
        }

        public IEnumerable<T> ListAll()
        {
            return _DbSet.ToList();
        }

        public void Remove(int id)
        {
            var query = _DbSet.Find(id);
            _DbSet.Remove(query);
        }
    }
}
