using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SampleWebApplication.Models.DB;
using SampleWebApplication.Models.ViewModel;

namespace SampleWebApplication.Models.MyRoles
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            using (var userContext = new ceit_gwa_databaseEntities1())
            {
                return userContext.CeitUserRoles.Select(r => r.Roles).ToArray();
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var userContext = new ceit_gwa_databaseEntities1())
            {
                var roles = userContext.CeitUsers.FirstOrDefault(u => u.LoginAccount == username);
                var userRoles = userContext.CeitUserRoles.Where(r => r.RoleId == roles.Roles);

                if (roles.Roles == null)
                {
                    return new string[] { };
                }
                else
                {
                    return userRoles.Select(u => u.Roles).ToArray();
                }
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (var userContext = new ceit_gwa_databaseEntities1())
            {
                var user = userContext.CeitUsers.SingleOrDefault(u => u.LoginAccount == username);
                var userRoles = userContext.CeitUserRoles.Select(r => r.RoleId);

                if (user == null)
                {
                    return false;
                }
                else
                {
                    return userRoles.Any(r => r == user.Roles);
                }
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}