using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Data
{
    public class RolePersistence : Persistence<Role>
    {
        private readonly RoleDataService roleDataService;

        public RolePersistence(RoleDataService roleDataService)
            : base(roleDataService)
        {
            this.roleDataService = roleDataService;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return roleDataService.GetAllRoles();
        }

        public IEnumerable<Role> SearchRoleByName(string name)
        {
            return roleDataService.SearchByName(name);
        }

        public IEnumerable<User> GetRoleUsers(Guid roleID)
        {
            return roleDataService.GetRoleUsers(roleID);
        }

        public IEnumerable<Feature> GetRoleFeatures(Guid roleID)
        {
            return roleDataService.GetRoleFeatures(roleID);
        }
    }
}
