using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneAppBackend.Core.Repositories.Framework
{
    public interface IBaseRepository<T>
    {
        int CommitChanges();
        T GetById(object id);
        IQueryable<T> GetCore();
        IQueryable<T> Get(Expression<Func<T, bool>> where, string includeProperties = "");
        IQueryable<T> Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        IQueryable<T> Get(params Expression<Func<T, object>>[] include);
        IEnumerable<T> GetAllActive();
        T Insert(T entity);
        T Update(T entity);
        T Update(T entity, int id);
        void SoftDelete(object id);
        void Delete(T entity);
        void Delete(object id);
    }
}
