using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FeatureSharp.Data
{
    public class UserDataService : DataServiceBase<User>
    {
        private FeatureSharpDbContext featureSharpDbContext;

        public UserDataService(FeatureSharpDbContext featureSharpDbContext)
            : base(featureSharpDbContext)
        {
            this.featureSharpDbContext = featureSharpDbContext;
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            var query = featureSharpDbContext.Set<User>().AsQueryable();
            var user = query.SingleOrDefault(u => email.Equals(u.Email, StringComparison.OrdinalIgnoreCase));

            return user;
        }

        public IEnumerable<User> SearchByName(string name, bool includeInactive = false)
        {
            var query = featureSharpDbContext.Set<User>().AsQueryable();
            var result = from u in query
                         where (includeInactive ? true : !u.Inactive)
                            && (u.FirstName.Contains(name)
                            || u.LastName.Contains(name)
                            || (u.FirstName + " " + u.LastName).Contains(name))
                         select u;

            return result;
        }

        public IEnumerable<User> GetInactiveUsers()
        {
            var query = featureSharpDbContext.Set<User>().AsQueryable();

            return query.Where(u => u.Inactive);
        }

        public IEnumerable<User> GetActiveUsers()
        {
            var query = featureSharpDbContext.Set<User>().AsQueryable();

            return query.Where(u => !u.Inactive);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return featureSharpDbContext.Users;
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

        public IEnumerable<Role> GetUserRoles(Guid userID)
        {
            return featureSharpDbContext.Roles.Join(
                featureSharpDbContext.RoleUsers.Where(ru => ru.UserID == userID)
                , r => r.ID
                , ru => ru.RoleID
                , (r, ru) => new Role
                {
                    ID = r.ID,
                    Name = r.Name,
                    Description = r.Description
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

        public Page<User> GetUsers(int pageIndex, int pageSize)
        {
            var page = new Page<User>(pageIndex, pageSize);
            var pagination = new Pagination<User>(page, featureSharpDbContext.Users);

            return pagination.Current;
        }
    }
}
