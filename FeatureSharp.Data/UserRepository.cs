using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Data
{
    public class UserRepository : Repository<UserPersistence, User>
    {
        private readonly UserPersistence userPersistenceObject;
        private readonly RolePersistence rolePersistenceObject;

        public UserRepository(UserPersistence userPersistenceObject)
            : base(userPersistenceObject)
        {
            this.userPersistenceObject = userPersistenceObject;
        }

        public UserRepository(UserPersistence userPersistenceObject
            , RolePersistence rolePersistenceObject)
            : this(userPersistenceObject)
        {
            this.rolePersistenceObject = rolePersistenceObject;
        }

        public bool IsInactive(Guid ID)
        {
            User user = PersitentObject.Get(ID);

            if (user == null)
                throw new Exception(string.Format("User:{0} is not exsits.", ID.ToString()));

            return user.Inactive;
        }

        public IEnumerable<User> GetUsersByRoleID(Guid roleID)
        {
            return userPersistenceObject.GetRoleUsers(roleID);
        }

        public IEnumerable<User> GetInactiveUsers()
        {
            return userPersistenceObject.GetInactiveUsers();
        }

        public IEnumerable<User> GetActiveUsers()
        {
            return userPersistenceObject.GetActiveUsers();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userPersistenceObject.GetAllUsers();
        }

        public IEnumerable<User> SearchUserByName(string name, bool includeInactive = false)
        {
            return userPersistenceObject.SearchUserByName(name, includeInactive);
        }

        public Page<User> GetUsers(int pageIndex, int pageSize)
        {
            return userPersistenceObject.GetUsers(pageIndex, pageSize);
        }
    }
}
