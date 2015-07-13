using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Protiviti.Boilerplate.Server.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private static readonly string[] _emptyArray = new string[0];
        //Mark this variable true if logged in user is not a part of 
        bool userInvalid = false;
        bool roleInvalid = false;
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            //return base.IsAuthorized(actionContext);

            IPrincipal user = actionContext.ControllerContext.RequestContext.Principal;
            if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return false;
            }

            if (Users.Length > 0 && !SplitString(Users).Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
            {
                userInvalid = true;
                return false;
            }

            if (Roles.Length > 0 && !SplitString(Roles).Any(user.IsInRole))
            {
                roleInvalid = true;
                return false;
            }

            return true;
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            //base.HandleUnauthorizedRequest(actionContext);
            string error = "Authorization has been denied for this request.";
            if (roleInvalid)
            {
                error = error + " Only users in roles (" + Roles + ") are allowed to access this resource.";
            }
            actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, error);

        }

        /// <summary>
        /// Splits the string on commas and removes any leading/trailing whitespace from each result item.
        /// </summary>
        /// <param name="original">The input string.</param>
        /// <returns>An array of strings parsed from the input <paramref name="original"/> string.</returns>
        internal static string[] SplitString(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return _emptyArray;
            }

            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray();
        }
    }
}