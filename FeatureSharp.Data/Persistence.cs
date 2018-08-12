using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Data
{
    public abstract class Persistence<T> : IPersistent<T> where T : class, new()
    {
        protected readonly DataServiceBase<T> dataService;

        public Persistence(DataServiceBase<T> dataService)
        {
            this.dataService = dataService;
        }

        public virtual void Add(T item)
        {
            dataService.Add(item);
        }

        public virtual T Get(object key)
        {
            return dataService.Get(key);
        }

        public virtual void Remove(object key)
        {
            dataService.Delete(key);
        }

        public virtual void Update(T item)
        {
            dataService.Update(item);
        }
    }
}
