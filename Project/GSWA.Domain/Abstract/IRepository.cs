using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GSWA.Domain.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Create(T item);
        T FindById(Guid id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetWithInclude(Func<T, bool> predicate,params Expression<Func<T, object>>[] includeProperties);
    }
}
