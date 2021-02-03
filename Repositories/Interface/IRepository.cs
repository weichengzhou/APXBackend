
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace APX.Repositories
{
    public interface IRepository<T>
    {
        Task Create(T entity);

        Task<T> FindFirst(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> FindAll();

        void Update(T entity);

        void Remove(T entity);
    }
}