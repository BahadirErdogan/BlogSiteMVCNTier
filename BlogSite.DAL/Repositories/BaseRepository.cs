using BlogSite.Core.Entities;
using BlogSite.Core.Enums;
using BlogSite.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext appDbContext;
        protected DbSet<T> table;

        public BaseRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            table = appDbContext.Set<T>();
        }

        public async Task<bool> Any(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await table.AnyAsync(expression);
        }

        public async Task Create(T entity)
        {
            table.Add(entity);
            await appDbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            entity.DeleteDate = DateTime.Now;
            entity.Status = Status.Passive;
            appDbContext.SaveChanges();
        }

        public async Task<List<T>> GetAllWhere(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).ToListAsync();
        }

        // Sorgu yazarken incelenecek
        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(System.Linq.Expressions.Expression<Func<T, TResult>> selector, System.Linq.Expressions.Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = table;
            if (includes != null) query = includes(query);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).FirstOrDefaultAsync();
            }
            else return await query.Select(selector).FirstOrDefaultAsync();
        }

        // Sorgu yazarken incelenecek
        public async Task<List<TResult>> GetFilteredList<TResult>(System.Linq.Expressions.Expression<Func<T, TResult>> selector, System.Linq.Expressions.Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = table;
            if (includes != null) query = includes(query);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).ToListAsync();
            }
            else return await query.Select(selector).ToListAsync();
        }

        public async Task<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await table.FirstOrDefaultAsync(expression);
        }

        public void Update(T entity)
        {
            appDbContext.Entry<T>(entity).State = EntityState.Modified;
            appDbContext.SaveChanges();
        }
    }
}
