﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Protiviti.Boilerplate.Server.Api.Registration;
using Protiviti.Boilerplate.Server.Results;
using Protiviti.Boilerplate.Server.Providers;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Web.Routing;
using Protiviti.Boilerplate.Server.Api.Helper;
using System.Transactions;

namespace Protiviti.Boilerplate.Server.Api.Account
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/Account/UserInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            return new UserInfoViewModel
            {
                Email = User.Identity.GetUserName(),
                HasRegistered = externalLogin == null,
                LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
            };
        }

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        // GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
        [Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

            foreach (IdentityUserLogin linkedAccount in user.Logins)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = linkedAccount.LoginProvider,
                    ProviderKey = linkedAccount.ProviderKey
                });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = LocalLoginProvider,
                    ProviderKey = user.UserName,
                });
            }

            return new ManageInfoViewModel
            {
                LocalLoginProvider = LocalLoginProvider,
                Email = user.UserName,
                Logins = logins,
                ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
            };
        }

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                    model.NewPassword);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/Account/AdminChangeUserPassword
        [Route("AdminChangeUserPassword")]
        public async Task<IHttpActionResult> AdminChangeUserPassword(SetPasswordBindingModel model, string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var token = (await UserManager.GeneratePasswordResetTokenAsync(userId)).ToString();
                //Task<IdentityResult> result1 = UserManager.RemovePasswordAsync(User.Identity.GetUserId());
                IdentityResult result = await UserManager.ResetPasswordAsync(userId, token, model.NewPassword);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // POST api/Account/SetPassword
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/AddExternalLogin
        [Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null || (ticket.Properties != null
                && ticket.Properties.ExpiresUtc.HasValue
                && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return BadRequest("External login failure.");
            }

            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return BadRequest("The external login is already associated with an account.");
            }

            IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
                new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/RemoveLogin
        [Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result;

            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
            }
            else
            {
                result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
                    new UserLoginInfo(model.LoginProvider, model.ProviderKey));
            }

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // GET api/Account/Login
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ApplicationCookie)]
        [AllowAnonymous]
        [HttpPost]
        [Route("Login", Name = "InternalLogin")]
        public async Task<IHttpActionResult> GetLogin(LoginViewModel model)
        {
            //if (error != null)
            //{
            //    return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            //}

            //if (!User.Identity.IsAuthenticated)
            //{
            //    return new ChallengeResult(provider, this);
            //}

            //ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            //if (externalLogin == null)
            //{
            //    return InternalServerError();
            //}

            //if (externalLogin.LoginProvider != provider)
            //{
            //    Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            //    return new ChallengeResult(provider, this);
            //}
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Request.GetOwinContext().Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = await userManager.FindAsync(model.Email, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("invalid_grant", "The user name or password is incorrect.");
                return BadRequest(ModelState);
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
                   OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
                CookieAuthenticationDefaults.AuthenticationType);
            var _roles = await UserManager.GetRolesAsync(user.Id);
            AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user, string.Join(",", _roles));

            Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            return Ok();
        }

        // GET api/Account/ExternalLogin
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            string redirectUri = string.Empty;

            if (error != null)
            {
                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            var redirectUriValidationResult = ValidateClientAndRedirectUri(this.Request, ref redirectUri);

            if (!string.IsNullOrWhiteSpace(redirectUriValidationResult))
            {
                return BadRequest(redirectUriValidationResult);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            redirectUri = string.Format("{0}#external_access_token={1}&provider={2}&haslocalaccount={3}&external_user_name={4}",
                                            redirectUri,
                                            externalLogin.ExternalAccessToken,
                                            externalLogin.LoginProvider,
                                            hasRegistered.ToString(),
                                            externalLogin.UserName);

            return Redirect(redirectUri);

            //if (hasRegistered)
            //{
            //    Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            //    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
            //       OAuthDefaults.AuthenticationType);
            //    ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
            //        CookieAuthenticationDefaults.AuthenticationType);
            //    var _roles = await UserManager.GetRolesAsync(user.Id);
            //    //AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user, string.Join(",", _roles));// (user.UserName, user.DisplayName);
            //    AuthenticationProperties properties = SimpleAuthorizationServerProvider.CreateProperties(user, string.Join(",", _roles));// (user.UserName,user.DisplayName);
            //    Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            //}
            //else
            //{
            //    IEnumerable<Claim> claims = externalLogin.GetClaims();
            //    ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
            //    Authentication.SignIn(identity);
            //}
            //return Ok();
        }

        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
            List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (AuthenticationDescription description in descriptions)
            {
                ExternalLoginViewModel login = new ExternalLoginViewModel
                {
                    Name = description.Caption,
                    Url = Url.Route("ExternalLogin", new
                    {
                        provider = description.AuthenticationType,
                        response_type = "token",
                        client_id = Startup.PublicClientId,
                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
                        state = state
                    }),
                    State = state
                };
                logins.Add(login);
            }

            return logins;
        }

        /// <summary>
        /// Register internal users to site
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST api/Account/Register
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var regContext = new RegistrationController();
            if (regContext.IsDuplicateEmail(model.Email))
            {
                return BadRequest("Email ID already exists");
            }


            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Person.Contact.Phone,
                DisplayName = model.DisplayName
            };

            IdentityResult result;


            try
            {
                result = await UserManager.CreateAsync(user, model.Password).ConfigureAwait(false);
                // Note that because of the ConfigureAwait(false), we are not on the original context here.
                // Instead, we're running on the thread pool.

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                else
                {

                    //Enable two factor authentication
                    result = await UserManager.SetTwoFactorEnabledAsync(user.Id, true).ConfigureAwait(false);
                    if (!result.Succeeded)
                    {
                        return GetErrorResult(result);
                    }

                    /* Insert a new record into the People table
                    */

                    var personResult = new RegistrationController().CreatePerson(model.Person);

                    // Sending verification code
                    var provider = "EmailCode";
                    var token = await UserManager.GenerateTwoFactorTokenAsync(user.Id, provider).ConfigureAwait(false);
                    // See IdentityConfig.cs to plug in Email/SMS services to actually send the code
                    result = await UserManager.NotifyTwoFactorTokenAsync(user.Id, provider, token);
                    if (!result.Succeeded)
                    {
                        return GetErrorResult(result);
                    }
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        // POST api/Account/RegisterExternal
        [AllowAnonymous]
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var verifiedAccessToken = await VerifyExternalAccessToken(model.Provider, model.ExternalAccessToken);
            if (verifiedAccessToken == null)
            {
                return BadRequest("Invalid Provider or External Access Token");
            }

            //IdentityUser user = await _repo.FindAsync(new UserLoginInfo(model.Provider, verifiedAccessToken.user_id));
            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(model.Provider, verifiedAccessToken.user_id));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                return BadRequest("External user is already registered");
            }

            //user = new IdentityUser() { UserName = model.UserName };
            user = new ApplicationUser() { UserName = model.UserName };

            //IdentityResult result = await _repo.CreateAsync(user);
            IdentityResult result = await UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            var info = new ExternalLoginInfo()
            {
                DefaultUserName = model.UserName,
                Login = new UserLoginInfo(model.Provider, verifiedAccessToken.user_id)
            };

            //result = await _repo.AddLoginAsync(user.Id, info.Login);
            result = await UserManager.AddLoginAsync(user.Id, info.Login);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            //generate access token response
            var accessTokenResponse = await GenerateLocalAccessTokenResponse(model.UserName);

            return Ok(accessTokenResponse);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ObtainLocalAccessToken")]
        public async Task<IHttpActionResult> ObtainLocalAccessToken(string provider, string externalAccessToken)
        {

            if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(externalAccessToken))
            {
                return BadRequest("Provider or external access token is not sent");
            }

            var verifiedAccessToken = await VerifyExternalAccessToken(provider, externalAccessToken);
            if (verifiedAccessToken == null)
            {
                return BadRequest("Invalid Provider or External Access Token");
            }

            //IdentityUser user = await _repo.FindAsync(new UserLoginInfo(provider, verifiedAccessToken.user_id));
            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(provider, verifiedAccessToken.user_id));

            bool hasRegistered = user != null;

            if (!hasRegistered)
            {
                return BadRequest("External user is not registered");
            }

            //generate access token response
            var accessTokenResponse = await GenerateLocalAccessTokenResponse(user.UserName);

            return Ok(accessTokenResponse);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UserManager.Dispose();
            }

            base.Dispose(disposing);
        }

        #region VerifyCode

        /// <summary>
        /// Get two factor authentication providers 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Providers")]
        public async Task<IList<string>> GetValidTwoFactorProviders(JObject userInfo)
        {
            string userName = ((dynamic)userInfo).Email.Value;
            string password = ((dynamic)userInfo).Password.Value;
            var user = await UserManager.FindAsync(userName, password);
            if (user == null)
            {
                return null;
            }
            // Get two-factor providers
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(user.Id);
            return userFactors;

        }

        /// <summary>
        /// Send the activation code on demand
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("SendCode")]
        public async Task<bool> SendCode(JObject userInfo)
        {
            string userName = ((dynamic)userInfo).Email.Value;
            string password = ((dynamic)userInfo).Password.Value;
            string provider = ((dynamic)userInfo).Provider.Value;
            var user = await UserManager.FindAsync(userName, password);
            if (user == null)
            {
                return false;
            }

            var token = await UserManager.GenerateTwoFactorTokenAsync(user.Id, provider);
            // See IdentityConfig.cs to plug in Email/SMS services to actually send the code
            await UserManager.NotifyTwoFactorTokenAsync(user.Id, provider, token);
            return true;

        }

        /// <summary>
        /// Verify the activation code
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("VerifyCode")]
        public async Task<JObject> VerifyCode(JObject userInfo)
        {
            string userName = ((dynamic)userInfo).Email.Value;
            string password = ((dynamic)userInfo).Password.Value;
            string provider = ((dynamic)userInfo).Provider.Value;
            string code = ((dynamic)userInfo).Code.Value;

            var user = await UserManager.FindAsync(userName, password);
            if (user == null)
            {
                return null;
            }

            if (await UserManager.VerifyTwoFactorTokenAsync(user.Id, provider, code))
            {
                // When token is verified correctly, clear the access failed 
                // count used for lockout
                await UserManager.ResetAccessFailedCountAsync(user.Id);
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = true;
                await UserManager.UpdateAsync(user);
                return await GenerateLocalAccessTokenResponse(user.UserName);
            }

            return null;

        }
        #endregion

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public string ExternalAccessToken { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer) || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name),
                    ExternalAccessToken = identity.FindFirstValue("ExternalAccessToken"),
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        private string ValidateClientAndRedirectUri(HttpRequestMessage request, ref string redirectUriOutput)
        {

            Uri redirectUri;

            var redirectUriString = GetQueryString(Request, "redirect_uri");

            if (string.IsNullOrWhiteSpace(redirectUriString))
            {
                return "redirect_uri is required";
            }

            bool validUri = Uri.TryCreate(redirectUriString, UriKind.Absolute, out redirectUri);

            if (!validUri)
            {
                return "redirect_uri is invalid";
            }

            var clientId = GetQueryString(Request, "client_id");

            if (string.IsNullOrWhiteSpace(clientId))
            {
                return "client_Id is required";
            }

            var ctx = Request.GetOwinContext().Get<ApplicationDbContext>();
            var client = ctx.Clients.Find(clientId);
            if (client == null)
            {
                return string.Format("Client_id '{0}' is not registered in the system.", clientId);
            }

            if (!string.Equals(client.AllowedOrigin, redirectUri.GetLeftPart(UriPartial.Authority), StringComparison.OrdinalIgnoreCase))
            {
                return string.Format("The given URL is not allowed by Client_id '{0}' configuration.", clientId);
            }

            redirectUriOutput = redirectUri.AbsoluteUri;

            return string.Empty;

        }

        private string GetQueryString(HttpRequestMessage request, string key)
        {
            var queryStrings = request.GetQueryNameValuePairs();

            if (queryStrings == null) return null;

            var match = queryStrings.FirstOrDefault(keyValue => string.Compare(keyValue.Key, key, true) == 0);

            if (string.IsNullOrEmpty(match.Value)) return null;

            return match.Value;
        }

        private async Task<ParsedExternalAccessToken> VerifyExternalAccessToken(string provider, string accessToken)
        {
            ParsedExternalAccessToken parsedToken = null;

            var verifyTokenEndPoint = "";

            if (provider == "Facebook")
            {
                //You can get it from here: https://developers.facebook.com/tools/accesstoken/
                //More about debug_tokn here: http://stackoverflow.com/questions/16641083/how-does-one-get-the-app-access-token-for-debug-token-inspection-on-facebook
                var appToken = ServerSettings.Instance.Facebook_App_Token;
                verifyTokenEndPoint = string.Format("https://graph.facebook.com/debug_token?input_token={0}&access_token={1}", accessToken, appToken);
            }
            else if (provider == "Google")
            {
                verifyTokenEndPoint = string.Format("https://www.googleapis.com/oauth2/v1/tokeninfo?access_token={0}", accessToken);
            }
            else
            {
                return null;
            }

            var client = new HttpClient();
            var uri = new Uri(verifyTokenEndPoint);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                parsedToken = new ParsedExternalAccessToken();

                if (provider == "Facebook")
                {
                    parsedToken.user_id = jObj["data"]["user_id"];
                    parsedToken.app_id = jObj["data"]["app_id"];

                    if (!string.Equals(Startup.facebookAuthOptions.AppId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }
                }
                else if (provider == "Google")
                {
                    parsedToken.user_id = jObj["user_id"];
                    parsedToken.app_id = jObj["audience"];

                    if (!string.Equals(Startup.googleAuthOptions.ClientId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }

                }

            }

            return parsedToken;
        }

        private async Task<JObject> GenerateLocalAccessTokenResponse(string userName)
        {

            var tokenExpiration = TimeSpan.FromDays(1);


            ApplicationUser user = await UserManager.FindByNameAsync(userName);

            if (user == null || user.IsActive == false)
            {
                return null;
            }

            var _roles = await UserManager.GetRolesAsync(user.Id);

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager, OAuthDefaults.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, userName));
            oAuthIdentity.AddClaim(new Claim("sub", userName));
            if (_roles.Contains(IdentityConstants.Roles.Administrator))
            {
                oAuthIdentity.AddClaim(new Claim("role", IdentityConstants.Roles.Administrator));
            }

            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
            };

            var ticket = new AuthenticationTicket(oAuthIdentity, props);

            var accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

            /* If not external user for e.g. social logins (Google, Facebook etc)
            Then display is the combination of First & Last Name
            **/
            if (user.Logins.Count == 0)
            {
                var person = new RegistrationController().GetPerson(user.UserName);
                user.DisplayName = person != null ? person.FirstName + " " + person.LastName : user.DisplayName;
            }

            JObject tokenResponse = new JObject(
                                        new JProperty("userName", userName),
                                        new JProperty("displayName", user.DisplayName ?? user.UserName),
                                        new JProperty("roles", string.Join(",", _roles)),
                                        new JProperty("access_token", accessToken),
                                        new JProperty("token_type", "bearer"),
                                        new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                                        new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                                        new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString())
        );

            return tokenResponse;
        }

        #endregion
    }
}
