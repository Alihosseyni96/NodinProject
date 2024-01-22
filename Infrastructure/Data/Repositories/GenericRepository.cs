using Domain.IRepositories;
using Infrastructure.Common.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<IEnumerable<TEntity>> Read(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return await dbSet.Where(filter).SetIncludes(includes).ToListAsync();
        }

        public  void RemoveAsync(TEntity entity)
        {
             dbSet.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return await dbSet.SetIncludes(includes).SingleOrDefaultAsync(predicate: filter);
        }

        public void UpdateAsync(TEntity entity)
        {
             dbSet.Update(entity);

        }

    }

    
}
