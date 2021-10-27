using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneAppBackend.Core.Framework
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        protected TaskResult TaskResult { get; set; }

        protected BaseService()
        {
            TaskResult = new TaskResult { ExecutedSuccesfully = true };
        }

        public abstract TaskResult ValidateOnUpdate(T entity);
        public abstract TaskResult ValidateOnDelete(T entity);
        public abstract TaskResult ValidateOnCreate(T entity);

        public abstract TaskResult Update(T entity);
        public abstract TaskResult Delete(int entityId);
        public abstract TaskResult Create(T entity);

    }

    public interface IBaseService<T>
    {
        TaskResult ValidateOnCreate(T entity);
        TaskResult ValidateOnUpdate(T entity);
        TaskResult ValidateOnDelete(T entity);

        TaskResult Update(T entity);

        TaskResult Delete(int entityId);
        TaskResult Create(T entity);
    }
}
