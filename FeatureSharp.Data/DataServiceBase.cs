using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Data
{
    public abstract class DataServiceBase<T> where T : class, new()
    {
        protected DbContext dbContext;

        public DataServiceBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual void Add(T item)
        {
            dbContext.Add<T>(item);
            dbContext.SaveChanges();
        }

        public virtual T Get(Guid ID)
        {
            return dbContext.Find<T>(ID);
        }

        public virtual T Get(object key)
        {
            return dbContext.Find<T>(key);
        }

        public virtual void Delete(Guid ID)
        {
            object key = ID;
            Delete(key);
        }

        public virtual void Delete(object key)
        {
            T entity = dbContext.Find<T>(key);
            if (entity != null)
            {
                dbContext.Remove<T>(entity);
                dbContext.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            dbContext.Update<T>(entity);
            dbContext.SaveChanges();
        }
    }
}
