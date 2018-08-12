using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Models
{
    public class RoleUser
    {
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public Guid UserID { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
