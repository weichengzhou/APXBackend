using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace APX.Repositories
{
    public class AsyncRepository<T> : IRepository<T> where T : class
    {
        private DbContext Context { get; set; }

        public AsyncRepository(DbContext context)
        {
            this.Context = context;
        }


        public async Task Create(T entity)
        {
            await this.Context.Set<T>().AddAsync(entity);
        }

        public async Task<T> FindFirst(Expression<Func<T, bool>> predicate)
        {
            return await this.Context.Set<T>()
                .Where(predicate)
                .FirstOrDefaultAsync();
        }
        
        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await this.Context.Set<T>()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<List<T>> FindAll()
        {
            return await this.Context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            this.Context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            this.Context.Set<T>().Remove(entity);
        }
    }
}