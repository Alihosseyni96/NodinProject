using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Extentions
{
    public static class EntityExtentions
    {
        public static IQueryable<TEntity> SetIncludes<TEntity, TPrpperty>(this IQueryable<TEntity> query, Expression<Func<TEntity, TPrpperty>>[] includes)
        {
            if (includes is null || includes.Count() == 0)
            {
                return query;
            }
           query =  query.SetIncludes(includes);
            //foreach (var include in includes)
            //{
            //    query = query.Include(include);
            //}
            return query;
        }
    }
}
