using Protiviti.Boilerplate.Server.Api.Account.Entity;
using System.Collections.Generic;

namespace Protiviti.Boilerplate.Server.Api.Account
{
    public class IdentityConstants
    {
        public class ClaimTypes
        {
            public const string Subject = "sub";
            public const string Username = "username";
            public const string Name = "name";
            public const string Password = "password";
            public const string Email = "email";
            public const string Phone = "phone";
            public const string Role = "role";
            public const string Locality = "locality";
        }

        public class Roles
        {
            public const string Administrator = "Admin";
            public const string Member = "Member";
        }

        public const string AdminEmail = "admin@protiviti.com";

        #region Client Details

        public const string AudienceId = "ProtivitiBoilerplate";

        /// <summary>
        /// Contains the list of all clients. For bigger list we will optimize it in future
        /// </summary>
        public static List<Client> Clients;

        #endregion
    }
}