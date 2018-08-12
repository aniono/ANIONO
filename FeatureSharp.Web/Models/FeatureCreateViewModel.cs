using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureSharp.Web.Models
{
    public class FeatureCreateViewModel
    {
        [Required]
        public string FeatureName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }
    }
}
