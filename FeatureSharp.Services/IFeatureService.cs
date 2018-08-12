using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Services
{
    public interface IFeatureService
    {
        bool IsFeatureEnabled(string featureName);
        bool IsFeatureEnabled(Guid featureID);
        bool IsFeatureEnabledForUser(string featureName, Guid userID);
        bool IsFeatureEnabledForUser(Guid featureID, Guid userID);
        bool IsFeatureEnabledForRole(string featureName, Guid roleID);
        bool IsFeatureEnabledForRole(Guid featureID, Guid roleID);
    }
}
