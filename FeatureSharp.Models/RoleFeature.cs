using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Models
{
    public class RoleFeature
    {
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public Guid FeatureID { get; set; }
        public bool Enabled { get; set; }
        public Role Role { get; set; }
        public Feature Feature { get; set; }
    }
}
