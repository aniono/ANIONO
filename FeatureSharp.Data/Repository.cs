using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Data
{
    public abstract class Repository<T, U> where T : IPersistent<U>
    {
        protected readonly IPersistent<U> PersitentObject;

        protected Repository(IPersistent<U> persistentObject)
        {
            PersitentObject = persistentObject;
        }

        public virtual bool Add(U item)
        {
            try
            {
                PersitentObject.Add(item);
            }
            catch
            {
                throw;
            }

            return true;
        }

        public virtual bool Delete(object key)
        {
            try
            {
                PersitentObject.Remove(key);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public virtual U Get(Guid ID)
        {
            try
            {
                return PersitentObject.Get(ID);
            }
            catch
            {
                return default(U);
            }
        }

        public virtual U Get(string ID)
        {
            try
            {
                return PersitentObject.Get(ID);
            }
            catch
            {
                return default(U);
            }
        }

        public virtual U Get(int ID)
        {
            try
            {
                return PersitentObject.Get(ID);
            }
            catch
            {
                return default(U);
            }
        }

        public virtual bool Update(U item)
        {
            try
            {
                PersitentObject.Update(item);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
