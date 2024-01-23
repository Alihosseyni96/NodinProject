using Domain.IRepositories;
using Infrastructure.Common.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public  NodinContext _context;
        private Microsoft.EntityFrameworkCore.DbSet<TEntity>? dbSet; 

        public GenericRepository(NodinContext context)
        {
            _context = context;
             dbSet =  _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);

        }

        public async Task<IEnumerable<TEntity>> Read(Expression<Func<TEntity, bool>>? filter=null, params Expression<Func<TEntity, object>>[]? includes)
        {
            var res = dbSet.AsQueryable();
            if (filter != null)
                res = res.Where(filter);
            return await res.AsNoTracking().SetIncludes(includes).ToListAsync();

        }

        public  void Remove(TEntity entity)
        {
             dbSet.Remove(entity);
        }


        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>>? filter=null, params Expression<Func<TEntity, object>>[]? includes)
        {
            var res = dbSet.AsQueryable();
            if (filter != null)
                res = res.Where(filter);

            return await res
                .AsNoTracking()
                .SetIncludes(includes)
                .SingleOrDefaultAsync(predicate: filter);
              
        }

        public async Task<IEnumerable<TEntity>> ReadIf(bool condition , Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[]? includes)
        {
            var res = dbSet.AsQueryable();
            if (condition)
                res = res.Where(filter);
            return await res.AsNoTracking().SetIncludes(includes).ToListAsync();

        }

        public void UpdateAsync(TEntity entity)
        {
             dbSet.Update(entity);

        }

    }

    
}
