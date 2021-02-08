using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace APX.Repositories
{
    // Implement the method of IRepository.
    public class AsyncRepository<T> : IRepository<T> where T : class
    {
        private DbContext _context;

        public AsyncRepository(DbContext context)
        {
            this._context = context;
        }


        public async Task Create(T entity)
        {
            await this._context.Set<T>().AddAsync(entity);
        }

        public async Task<T> FindFirst(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>()
                .Where(predicate)
                .FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }
    }
}