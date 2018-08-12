using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureSharp.Web.Models
{
    public class FeatureEditViewModel
    {
        public Guid FeatureID { get; set; }

        [Required]
        public string FeatureName { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }
    }
}
