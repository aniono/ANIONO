using FeatureSharp.Data;
using System;

namespace FeatureSharp.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly FeatureRepository featureRepository;

        public FeatureService(FeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public bool IsFeatureEnabled(string featureName)
        {
            return featureRepository.IsFeatureEnabled(featureName);
        }

        public bool IsFeatureEnabled(Guid featureID)
        {
            return featureRepository.IsFeatureEnabled(featureID);
        }

        public bool IsFeatureEnabledForRole(string featureName, Guid roleID)
        {
            return featureRepository.IsFeatureEnabledForRole(featureName, roleID);
        }

        public bool IsFeatureEnabledForRole(Guid featureID, Guid roleID)
        {
            return featureRepository.IsFeatureEnabledForRole(featureID, roleID);
        }

        public bool IsFeatureEnabledForUser(string featureName, Guid userID)
        {
            return featureRepository.IsFeatureEnabledForUser(featureName, userID);
        }

        public bool IsFeatureEnabledForUser(Guid featureID, Guid userID)
        {
            return featureRepository.IsFeatureEnabledForUser(featureID, userID);
        }
    }
}
