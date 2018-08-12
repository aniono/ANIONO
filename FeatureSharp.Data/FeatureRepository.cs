using FeatureSharp.Models;
using System;

namespace FeatureSharp.Data
{
    public class FeatureRepository : Repository<IPersistent<Feature>, Feature>
    {
        private readonly FeaturePersistence featurePersistence;

        public FeatureRepository(FeaturePersistence featurePersistence)
            : base(featurePersistence)
        {
            this.featurePersistence = featurePersistence;
        }

        public bool IsFeatureEnabled(Guid ID)
        {
            Feature feature = Get(ID);
            if (feature == null)
                throw new Exception(string.Format("Feature:{0} is not exists.", ID.ToString()));

            return feature.Enabled;
        }

        public bool IsFeatureEnabled(string name)
        {
            return featurePersistence.IsFeatureEnabled(name);
        }

        public bool IsFeatureEnabledForRole(string featureName, Guid roleID)
        {
            return featurePersistence.IsFeatureEnabledForRole(featureName, roleID);
        }

        public void EnableFeature(Guid ID)
        {
            Feature feature = Get(ID);
            if (feature == null)
                throw new Exception(string.Format("Feature:{0} is not exists.", ID.ToString()));

            feature.Enabled = true;
            Update(feature);
        }

        public void DisableFeature(Guid ID)
        {
            Feature feature = Get(ID);
            if (feature == null)
                throw new Exception(string.Format("Feature:{0} is not exists.", ID.ToString()));

            feature.Enabled = false;
            Update(feature);
        }

        public bool IsFeatureEnabledForUser(string featureName, Guid userID)
        {
            return featurePersistence.IsFeatureEnabledForRole(featureName, userID);
        }

        public bool IsFeatureEnabledForRole(Guid featureID, Guid roleID)
        {
            return featurePersistence.IsFeatureEnabledForRole(featureID, roleID);
        }

        public bool IsFeatureEnabledForUser(Guid featureID, Guid userID)
        {
            return featurePersistence.IsFeatureEnabledForUser(featureID, userID);
        }
    }
}
