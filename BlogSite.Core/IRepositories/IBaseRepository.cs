using BlogSite.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.IRepositories
{
    public interface IBaseRepository<T> where T: IBaseEntity
    {
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<T> GetWhere(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllWhere(Expression<Func<T, bool>> expression);

        //For single entity;
        Task<TResult> GetFilteredFirstOrDefault<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        //For multiple entity
        Task<List<TResult>> GetFilteredList<TResult>(
           Expression<Func<T, TResult>> selector,
           Expression<Func<T, bool>> expression,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
    }
}
