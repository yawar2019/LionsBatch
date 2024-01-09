using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SampleProject.Models
{
    public class CustomRoles : RoleProvider
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-L1958T5\\SQLSERVER;Initial Catalog=HarshaDb;Integrated Security=true");

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

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var users =con.Query<Users>("Select  * from Login");
            var Roles= con.Query<Roles>("Select  * from tblRole");
            var UserRoleMapping = con.Query<RoleUserMapping>("Select  * from UserRoleMapping");

            string[] FinalRoles = (from user in users
                                  join userRolemap in UserRoleMapping
                                  on user.UserId equals userRolemap.UserId

                                  join role in Roles
                                  on userRolemap.RoleId equals role.RoleId

                                   where user.UserName==username
                                   select role.RoleName ).ToArray();

            return FinalRoles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
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
    }
}