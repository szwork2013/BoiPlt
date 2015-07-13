using Breeze.WebApi2;
using Protiviti.Boilerplate.Server.Logging;
using System;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Breeze.ContextProvider.EF6;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Collections.Generic;

namespace Protiviti.Boilerplate.Server.Api.Account
{
    [SlabLoggingFilter]
    [BreezeController]
    [RoutePrefix("api/UserManager")]
    [Authorize(Roles = IdentityConstants.Roles.Administrator)]
    public class UserManagerController : ApiController
    {
        // Initialize entity framework breeze controller
        private EFContextProvider<ApplicationDbContext> _contextProvider = new EFContextProvider<ApplicationDbContext>();
        private EFContextProvider<Registration.RegistrationDbContext> _registrationContext = new EFContextProvider<Registration.RegistrationDbContext>();
        public UserManagerController()
        {
        }

        /// <summary>
        /// Get the list of all employees
        /// </summary>
        /// <remarks>list of all employees</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("Users")]
        public IQueryable<ApplicationUser> Users()
        {


            return _contextProvider.Context.Users;

        }

        [HttpGet]
        [Route("ExternalLogins")]
        public IQueryable<ApplicationUser> ExternalLogins()
        {
            return _contextProvider.Context.Users.Where(x => x.IsActive == true && x.Logins.Count > 0);
        }


        // ~/breeze/UserManager/Metadata
        [HttpGet]
        [Route("Metadata")]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpPost]
        [Route("UpdateRoles")]
        public async Task<IdentityResult> UpdateRoles(JObject roles)
        {
            string userId = ((dynamic)roles).Id.Value;
            string roleId = ((dynamic)roles).RoleId.Value;
            string roleName = ((dynamic)roles).RoleName.Value;

            IdentityResult result = null;

            #region TODO: Remove unused commented code
            //IdentityRole role = (from r in _contextProvider.Context.Roles where r.Id == roleId select r).FirstOrDefault();
            //var user = _contextProvider.Context.Users.Where(x => x.Id == userId).FirstOrDefault();
            //if (user.Roles.Any(x => x.RoleId == roleId))
            //{
            //    // User is in the Admin Role

            //}
            //else
            //{

            //    //User is not in the Admin Role
            //}

            //var role = (from r in _contextProvider.Context.Roles where r.Id == roleId select r).FirstOrDefault();
            //var users = _contextProvider.Context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();
            //if (users.Find(x => x.Id == userId) != null)
            //{
            //    // User is in the Admin Role
            //}
            //else
            //{

            //    //User is not in the Admin Role
            //}
            #endregion

            var userStore = new UserStore<ApplicationUser>(_contextProvider.Context);
            var userManager = new ApplicationUserManager(userStore);

            var roleStore = new RoleStore<IdentityRole>(_contextProvider.Context);
            var roleManager = new ApplicationRoleManager(roleStore);

            ApplicationUser user = await userManager.FindByIdAsync(userId);//.ConfigureAwait(false);

            IList<string> role = new List<string>();
            role.Add(roleName);
            if (user.Roles.Any(x => x.RoleId == roleId))
            {
                //remove user and roll mapping
                result = await userManager.RemoveUserFromRolesAsync(userId, role).ConfigureAwait(false);
                result = await userManager.RemoveClaimAsync(userId, new Claim(IdentityConstants.ClaimTypes.Role, roleName));
            }
            else
            {
                result = await userManager.AddUserToRolesAsync(userId, role).ConfigureAwait(false);
                result = await userManager.AddClaimAsync(userId, new Claim(IdentityConstants.ClaimTypes.Role, roleName));

                //User is not in the Admin Role
            }
            #region TODO: Remove unused commented code
            //if (user.Roles.Count > 0)
            //{
            //    var roleExists = user.Roles.First(x => x.RoleId == roleId);
            //    if (roleExists != null)
            //    {
            //        //remove user and roll mapping
            //        //result = await userManager.RemoveFromRoleAsync(userId, roleId).ConfigureAwait(false);
            //        //remove user and its claim
            //        //Claim c = new Claim();
            //        //c.Type = "role";
            //        //c.Value
            //        //result = await userManager.RemoveClaimAsync(userId,new Claim() { })

            //    }
            //    else
            //    {
            //        //result = await userManager.AddToRoleAsync(userId,roleId);
            //    }

            //}
            #endregion
            return await userManager.UpdateAsync(user).ConfigureAwait(false);
        }


        [HttpPost]
        [Route("DeleteUser")]
        public async Task<IdentityResult> DeleteUser(JObject deleteUser)
        {
            string userName = ((dynamic)deleteUser).Name.Value;

            IdentityResult result = null;

            var userStore = new UserStore<ApplicationUser>(_contextProvider.Context);
            var userManager = new ApplicationUserManager(userStore);

            var roleStore = new RoleStore<IdentityRole>(_contextProvider.Context);
            var roleManager = new ApplicationRoleManager(roleStore);

            ApplicationUser user = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
            if (user != null)
            {
                //We only do soft delete
                user.IsActive = false;
                result = await userManager.UpdateAsync(user).ConfigureAwait(false);
                // Also disable person details
                var person = _registrationContext.Context.People.Where(x => x.UserName == user.UserName).FirstOrDefault();
                if (person != null)
                {
                    person.IsActive = false;
                    person.LastChangeDate = DateTime.Now;
                    var r = await _registrationContext.Context.SaveChangesAsync();
                }
            }

            return result;

        }

        [HttpPost]
        [Route("ActivateUser")]
        public async Task<IdentityResult> ActivateUser(JObject activeUser)
        {
            string userName = ((dynamic)activeUser).Name.Value;

            IdentityResult result = null;

            var userStore = new UserStore<ApplicationUser>(_contextProvider.Context);
            var userManager = new ApplicationUserManager(userStore);
               
            ApplicationUser user = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
            if (user != null)
            {                
                user.IsActive = true;
                result = await userManager.UpdateAsync(user).ConfigureAwait(false);
                // Also enable person details
                var person = _registrationContext.Context.People.Where(x => x.UserName == user.UserName).FirstOrDefault();
                if (person != null)
                {
                    person.IsActive = true;
                    person.LastChangeDate = DateTime.Now;
                    var r = await _registrationContext.Context.SaveChangesAsync();
                }
            }

            return result;

        }

    }
}
