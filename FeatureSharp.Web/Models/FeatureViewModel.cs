using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureSharp.Web.Models
{
    public class FeatureViewModel
    {
        public Guid FeatureID { get; set; }

        public string FeatureName { get; set; }
        
        public bool Enabled { get; set; }

        public string Description { get; set; }
    }
}
