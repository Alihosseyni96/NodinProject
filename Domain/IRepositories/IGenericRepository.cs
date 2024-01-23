﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity,bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> Read(Expression<Func<TEntity,bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        void UpdateAsync(TEntity entity);

        void RemoveAsync(TEntity entity);
    }
}
