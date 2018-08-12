using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FeatureSharp.Data
{
    public class UserPersistence : Persistence<User>
    {
        private readonly UserDataService userDataService;

        public UserPersistence(UserDataService userDataService)
            : base(userDataService)
        {

        }

        public User GetUserByEmail(string email)
        {
            return userDataService.GetUserByEmail(email);
        }

        public IEnumerable<User> GetInactiveUsers()
        {
            return userDataService.GetInactiveUsers();
        }

        public IEnumerable<User> GetActiveUsers()
        {
            return userDataService.GetActiveUsers();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userDataService.GetAllUsers();
        }

        public IEnumerable<User> GetRoleUsers(Guid roleID)
        {
            return userDataService.GetRoleUsers(roleID);
        }

        public IEnumerable<User> SearchUserByName(string name, bool includeInactive)
        {
            return userDataService.SearchByName(name, includeInactive);
        }

        public IEnumerable<Role> GetUserRoles(Guid userID)
        {
            return userDataService.GetUserRoles(userID);
        }

        public Page<User> GetUsers(int pageIndex, int pageSize)
        {
            return userDataService.GetUsers(pageIndex, pageSize);
        }

        public IEnumerable<Feature> GetUserFeatures(Guid userID)
        {
            IEnumerable<Guid> roleIDs = GetUserRoles(userID).Select(r => r.ID);
            IEnumerable<Feature> features = new List<Feature>();
            roleIDs.AsParallel().ForAll(roleID =>
                features.Concat(userDataService.GetRoleFeatures(roleID)));

            var featureComparer = new FeatureComparer();

            return features.Distinct(featureComparer);
        }
    }
}
