using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FeatureSharp.Data
{
    public class RoleDataService : DataServiceBase<Role>
    {
        private readonly FeatureSharpDbContext featureSharpDbContext;

        public RoleDataService(FeatureSharpDbContext featureSharpDbContext)
            : base(featureSharpDbContext)
        {
            this.featureSharpDbContext = featureSharpDbContext;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return featureSharpDbContext.Roles;
        }

        public IEnumerable<Role> SearchByName(string name)
        {
            var query = featureSharpDbContext.Set<Role>().AsQueryable();
            var result = from r in query
                         where r.Name.Contains(name) || string.IsNullOrEmpty(name)
                         select r;

            return result;
        }

        public IEnumerable<User> GetRoleUsers(Guid roleID)
        {
            return featureSharpDbContext.Users.Join(
                featureSharpDbContext.RoleUsers.Where(ru => ru.RoleID == roleID)
                , u => u.ID
                , ru => ru.UserID
                , (u, ru) => new User
                {
                    ID = u.ID,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Inactive = u.Inactive
                });
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
