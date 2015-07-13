using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Protiviti.Boilerplate.Server.Api.Account;
using Protiviti.Boilerplate.Server.Api.Account.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Protiviti.Boilerplate.Server.Api.Registration;
using Microsoft.Owin.Security.Cookies;

namespace Protiviti.Boilerplate.Server.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            string clientId = string.Empty;
            string clientSecret = string.Empty;
            Client client = null;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context 
                //if you want to force sending clientId/secrets once obtain access tokens. 
                context.Validated();
                //context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            client = IdentityConstants.Clients.Find(x => x.Id == context.ClientId);

            if (client == null)
            {
                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return Task.FromResult<object>(null);
            }

            if (client.ApplicationType == ApplicationTypes.NativeConfidential)
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return Task.FromResult<object>(null);
                }
                else
                {
                    if (client.Secret != Helper.GetHash(clientSecret))
                    {
                        context.SetError("invalid_clientId", "Client secret is invalid.");
                        return Task.FromResult<object>(null);
                    }
                }
            }

            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set<string>("clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set<string>("clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = context.OwinContext.Get<string>("clientAllowedOrigin");

            if (allowedOrigin == null) allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null || user.IsActive == false)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            /* Currently two-factor authentication is enabled for internal users
            * if EmailConfirmed and PhoneNumberConfirmed both are false then
            * verification code sent to user is not verified
            **/
            if (!user.EmailConfirmed && !user.PhoneNumberConfirmed)
            {
                context.SetError("user_requiresverification", "User is not verified. Use verification code send to email or phone no entered during registration process.");
                return;
            }
            if (await userManager.IsLockedOutAsync(user.Id))
            {
                context.SetError("user_lockedout", "User is locked out");
                return;// SignInStatus.LockedOut;
            }
            var _roles = await userManager.GetRolesAsync(user.Id);

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, OAuthDefaults.AuthenticationType);

            //var oAuthIdentity = new ClaimsIdentity("JWT");

            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            oAuthIdentity.AddClaim(new Claim("sub", context.UserName));
            if (_roles.Contains(IdentityConstants.Roles.Administrator))
            {
                oAuthIdentity.AddClaim(new Claim("role", IdentityConstants.Roles.Administrator));
            }

            var person = new RegistrationController().GetPerson(user.UserName);
            user.DisplayName = person != null ? person.FirstName + " " + person.LastName : user.DisplayName;

            AuthenticationProperties properties = CreateProperties(user, string.Join(",", _roles));
            //properties.Dictionary.Add("audience", IdentityConstants.AudienceId);
            properties.Dictionary.Add("audience", (context.ClientId == null) ? string.Empty : context.ClientId);

            var ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            //return Task.FromResult<object>(null);
            //context.Request.Context.Authentication.SignIn(cookiesIdentity);

        }

        /// <summary>
        /// Return some basic user info to be used for particular user session
        /// </summary>
        /// <param name="user"></param>
        /// <param name="rolesList"></param>
        /// <returns></returns>
        public static AuthenticationProperties CreateProperties(ApplicationUser user, string rolesList)// string userName, string displayName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", user.Email },
                { "displayName", user.DisplayName},
                { "roles", rolesList},
            };
            return new AuthenticationProperties(data);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

    }
}