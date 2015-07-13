using System;
using System.Collections.Generic;

namespace Protiviti.Boilerplate.Server.Api.Account
{
    // Models returned by AccountController actions.



    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
   
    public class UserProfileViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        //public string Salutation { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public List<RoleViewModel> Roles { get; set; }
    }
    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsEditable { get; set; }
    }

    
}
