using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureSharp.Web.Models
{
    public static class FeatureExtensions
    {
        public static FeatureViewModel ToFeatureViewModel(this Feature feature)
        {
            if (feature == null)
                return new FeatureViewModel();

            return new FeatureViewModel
            {
                FeatureID = feature.ID,
                FeatureName = feature.Name,
                Enabled = feature.Enabled,
                Description = feature.Description
            };
        }

        public static FeatureDetailsViewModel ToFeatureDetailsViewModel(this Feature feature)
        {
            if (feature == null)
                return new FeatureDetailsViewModel();

            return new FeatureDetailsViewModel
            {
                FeatureID = feature.ID,
                FeatureName = feature.Name,
                Enabled = feature.Enabled,
                Description = feature.Description,
                AuthorName = feature.Author?.FirstName + " " + feature.Author?.LastName
            };
        }

        public static FeatureEditViewModel ToFeatureEditViewModel(this Feature feature)
        {
            if (feature == null)
                return new FeatureEditViewModel();

            return new FeatureEditViewModel
            {
                FeatureID = feature.ID,
                FeatureName = feature.Name,
                Enabled = feature.Enabled,
                Description = feature.Description
            };
        }

        public static FeatureDeleteViewModel ToFeatureDeleteViewModel(this Feature feature)
        {
            if (feature == null)
                return new FeatureDeleteViewModel();

            return new FeatureDeleteViewModel
            {
                FeatureID = feature.ID,
                FeatureName = feature.Name,
                Description = feature.Description,
                Author = feature.Author?.FirstName + " " + feature.Author?.LastName
            };
        }
    }
}
