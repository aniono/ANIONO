using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Data
{
    public interface IPersistent<T>
    {
        void Add(T item);
        void Remove(object key);
        void Update(T item);
        T Get(object key);
    }
}
