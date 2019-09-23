using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using UserAwardsApp.Entities;

namespace UserAwardsApp.PL.UIWebPages.HelpersBLL
{
    public enum Roles
    {
        Guest,
        User,
        Admin,
    }
    public class MyRoleProvaider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            foreach (var account in Provaiders.accountLogic.GetAllAccounts())
            {
                if(account.Login == username && account.Role == roleName)
                {
                    return true;
                }
            }

            if (username == "Admin" && roleName == "Admin")
                return true;
            else return false;
        }
        public override string[] GetAllRoles()
        {
            
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if(username == "Guest")
            {
                return new string [] { "Guest" };
            }
            var account = Provaiders.accountLogic.GetAllAccounts().FirstOrDefault(myAcc => myAcc.Login == username);

            if(account != null)
            {
                switch (account.Role)
                {
                    case "Guest":
                        return new string[] { "Guest"};
                    case "User":
                        return new string[] { "User" };
                    case "Admin":
                        return new string[] { "Admin"};
                }
            }
            else
            {
                return new string[] { };
            }
            return new string[] { };
        }

        #region HideContracts
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }



        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}