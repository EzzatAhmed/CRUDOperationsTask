using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T: class 
    {
        IEnumerable<T> GetAll();
        T? GetByID(object ID);
        T Create(T entity);
        T update(T entity);
        bool Delete(object ID);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
        bool save();
        public T Save(T entity);


    }
}
