using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Data
{
    public class FeaturePersistence : Persistence<Feature>
    {
        private readonly FeatureDataService featureDataService;

        public FeaturePersistence(FeatureDataService featureDataService)
            : base(featureDataService)
        {
            this.featureDataService = featureDataService;
        }

        public bool IsFeatureEnabled(Guid featureID)
        {
            return featureDataService.IsFeatureEnabled(featureID);
        }

        public bool IsFeatureEnabled(string featureName)
        {
            return featureDataService.IsFeatureEnabled(featureName);
        }

        public bool IsFeatureEnabledForRole(Guid featureID, Guid roleID)
        {
            return featureDataService.IsFeatureEnabledForRole(featureID, roleID);
        }

        public bool IsFeatureEnabledForRole(string featureName, Guid roleID)
        {
            return featureDataService.IsFeatureEnabledForRole(featureName, roleID);
        }

        public bool IsFeatureEnabledForUser(Guid featureID, Guid userID)
        {
            return featureDataService.IsFeatureEnabledForUser(featureID, userID);
        }

        public bool IsFeaturenEnabledForUser(string featureName, Guid userID)
        {
            return featureDataService.IsFeatureEnabledForUser(featureName, userID);
        }

        public IEnumerable<Feature> GetRoleFeatures(Guid roleID)
        {
            return featureDataService.GetRoleFeatures(roleID);
        }
    }
}
