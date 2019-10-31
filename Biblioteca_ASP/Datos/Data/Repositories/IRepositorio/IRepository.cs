using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Datos
{
    public interface IRepository<T> where T: class
    {
        T GetByID(int id);
        IEnumerable<T> ListAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        void AddOrUpdate(T Entidad);
        void AddRange(IEnumerable<T> Entity);
        void Remove(int id);
        
    }
}
