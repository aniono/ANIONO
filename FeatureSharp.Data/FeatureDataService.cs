using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FeatureSharp.Data
{
    public class FeatureDataService : DataServiceBase<Feature>
    {
        private readonly FeatureSharpDbContext featureSharpDbContext;

        public FeatureDataService(FeatureSharpDbContext featureSharpDbContext)
            : base(featureSharpDbContext)
        {
            this.featureSharpDbContext = featureSharpDbContext;
        }

        public bool IsFeatureEnabled(Guid featureID)
        {
            return featureSharpDbContext.Features.Find(featureID).Enabled;
        }

        public bool IsFeatureEnabled(string featureName)
        {
            Feature feature = featureSharpDbContext.Features.AsQueryable()
                .SingleOrDefault(f => f.Name.Equals(featureName));

            if (feature == null)
                return false;

            return feature.Enabled;
        }

        public bool IsFeatureEnabledForRole(Guid featureID, Guid roleID)
        {
            bool enabled = IsFeatureEnabled(featureID)
                && featureSharpDbContext.Set<RoleFeature>().AsQueryable()
                    .Any(rf => rf.FeatureID == featureID && rf.RoleID == roleID);

            return enabled;
        }

        public bool IsFeatureEnabledForRole(string featureName, Guid roleID)
        {
            Feature feature = GetFeatureByName(featureName);

            if (feature == null)
                return false;

            return IsFeatureEnabledForRole(feature.ID, roleID);
        }

        public bool IsFeatureEnabledForUser(Guid featureID, Guid userID)
        {
            bool enabled = false;
            Feature feature = Get(featureID);

            if (feature == null || !feature.Enabled)
                return false;

            var queryFeatureRoles = featureSharpDbContext.Set<RoleFeature>().AsEnumerable()
                .Where(rf => rf.FeatureID == featureID && rf.Enabled)
                .Select(rf => rf.RoleID);

            if (!queryFeatureRoles.Any())
                return false;

            var queryUserRoles = featureSharpDbContext.RoleUsers
                .Where(ru => ru.UserID == userID)
                .Select(ru => ru.RoleID);

            enabled = queryFeatureRoles.Intersect(queryUserRoles).Any();          

            return enabled;
        }

        public bool IsFeatureEnabledForUser(string featureName, Guid userID)
        {
            Feature feature = GetFeatureByName(featureName);

            if (feature == null)
                return false;

            return IsFeatureEnabledForUser(feature.ID, userID);
        }

        public bool IsFeatureEnabledForUser(Guid featureID, Guid userID, Guid roleID)
        {
            bool enabled = false;

            if (!IsFeatureEnabled(featureID))
                return false;

            RoleFeature roleFeature = featureSharpDbContext.Set<RoleFeature>().AsQueryable()
                .SingleOrDefault(rf => rf.FeatureID == featureID && rf.RoleID == roleID);

            RoleUser roleUser = featureSharpDbContext.Set<RoleUser>().AsQueryable()
                .SingleOrDefault(ru => ru.UserID == userID && ru.RoleID == roleID);

            enabled = roleFeature != null && roleUser != null;

            return enabled;
        }

        public Feature GetFeatureByName(string featureName)
        {
            Feature feature = featureSharpDbContext.Features.AsQueryable()
                .SingleOrDefault(f => f.Name.Equals(featureName));

            return feature;
        }

        public IEnumerable<Feature> GetRoleFeatures(Guid roleID)
        {
            return featureSharpDbContext.Features.Join(
                featureSharpDbContext.RoleFeatures.Where(rf => rf.RoleID == roleID)
                , f => f.ID
                , rf => rf.FeatureID
                , (f, rf) => new Feature
                {
                    ID = f.ID,
                    Name = f.Name,
                    Description = f.Description,
                    AuthorId = f.AuthorId,
                    Author = f.Author,
                    Enabled = f.Enabled
                });
        }
    }
}
