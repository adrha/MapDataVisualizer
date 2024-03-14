using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Extension
{
    public static class AddOrUpdateDbRecordExtension
    {
        public static async Task<T> AddOrUpdateAsync<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null)
        where T : class, new()
        {
            var exists = predicate != null ? await dbSet.AnyAsync(predicate) : dbSet.Any();
            if (exists)
            {
                dbSet.Update(entity);
            }
            else
            {
                dbSet.Add(entity);
            }

            return entity;
        }

        public static T AddOrUpdate<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null)
        where T : class, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            if (exists)
            {
                dbSet.Update(entity);
            }
            else
            {
                dbSet.Add(entity);
            }

            return entity;
        }

    }
}
