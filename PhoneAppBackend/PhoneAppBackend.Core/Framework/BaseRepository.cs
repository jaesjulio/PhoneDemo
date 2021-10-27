using PhoneAppBackend.Core.DB;
using PhoneAppBackend.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace PhoneAppBackend.Core.Repositories.Framework
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly ApplicationDbContext Database;

        protected BaseRepository(ApplicationDbContext database)
        {
            Database = database;
        }

        public int CommitChanges()
        {
            return Database.SaveChanges();
        }
        
        public T GetById(object id)
        {
            return Database.Set<T>().Find(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> where, string includeProperties = "")
        {
            var query = Database.Set<T>().AsQueryable();

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (where != null)
                query = query.AsExpandable().Where(where);

            return query;
        }

        public IQueryable<T> GetCore()
        {
            return Database.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include)
        {
            var query = Database.Set<T>().AsQueryable();

            foreach (var includeProperty in include)
            {
                query = query.Include(includeProperty);
            }

            if (where != null)
                query = query.AsExpandable().Where(where);

            return query;
        }

        public IQueryable<T> Get(params Expression<Func<T, object>>[] include)
        {
            var query = Database.Set<T>().AsQueryable().AsExpandable();

            foreach (var includeProperty in include)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public IEnumerable<T> GetAllActive()
        {
            return Database.Set<T>().Where(p => p.IsDeleted == false && p.IsActive);
        }


        public virtual T Insert(T entity)
        {
            Database.Set<T>().Add(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            Database.Set<T>().Attach(entity);
            Database.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual T Update(T entity, int id)
        {
            var entry = Database.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                var attachedEntity = Database.Set<T>().Find(id);

                if (attachedEntity != null)
                {
                    entity.CreatedAt = attachedEntity.CreatedAt;
                    entity.Id = attachedEntity.Id;

                    var attachedEntry = Database.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
            return entity;
        }

        public virtual void SoftDelete(object id)
        {
            var entity = GetById(id);

            if (entity == null)
                throw new Exception("This object not exists");

            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;

            Update(entity);
        }

        public virtual void Delete(T entity)
        {
            Database.Set<T>().Remove(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);

        }
    }
}
