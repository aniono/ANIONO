using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Data
{
    public class FeatureComparer : IEqualityComparer<Feature>
    {
        public bool Equals(Feature x, Feature y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else
                return x.ID.Equals(y.ID);
        }

        public int GetHashCode(Feature obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}
