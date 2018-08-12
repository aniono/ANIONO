using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureSharp.Web.Models
{
    public class FeatureDeleteViewModel
    {
        public Guid FeatureID { get; set; }

        public string FeatureName { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }
    }
}
