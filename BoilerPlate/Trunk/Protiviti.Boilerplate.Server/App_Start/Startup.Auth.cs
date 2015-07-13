using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Protiviti.Boilerplate.Server.Api.Account;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Protiviti.Boilerplate.Server.Providers;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Protiviti.Boilerplate.Server.AuthorizationServer.Formats;
using System.Threading.Tasks;
using Protiviti.Boilerplate.Server.Api.Helper;
using Protiviti.Boilerplate.Server.Api.Account.Entity;
using System.Diagnostics;

namespace Protiviti.Boilerplate.Server
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthServerOptions { get; private set; }
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static GoogleOAuth2AuthenticationOptions googleAuthOptions { get; private set; }
        public static FacebookAuthenticationOptions facebookAuthOptions { get; private set; }


        public static WindowsAzureActiveDirectoryBearerAuthenticationOptions activeDirectoryOptions { get; private set; }

        /// <summary>
        /// ClientId used for OAuth authentication and token generation
        /// </summary>
        /// <returns></returns>
        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        protected void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            ConfigureOAuth(app);

        }

        /// <summary>
        /// Configure different properties of Web Api
        /// </summary>
        /// <param name="config"></param>
        protected HttpConfiguration ConfigureWebApi(HttpConfiguration config)
        {
            var container = Bootstrapper.ConfigureWebApiContainer();

            config = WebApiConfig.Register(config);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return config;
        }

        /// <summary>
        /// Configure the Api documentation using Swagger
        /// </summary>
        /// <param name="config"></param>
        protected void ConfigureApiDocumentation(HttpConfiguration config)
        {
            // Registering swagger api 
            Swashbuckle.Bootstrapper.Init(config);
        }

        /// <summary>
        /// Configure cookie based authentication using OWIN middleware
        /// </summary>
        /// <param name="app"></param>
        protected void ConfigureCookieAuthentication(IAppBuilder app)
        {
            /// Enable the application to use a cookie to store information for the 
            // signed in user and to use a cookie to temporarily store information 
            // about a user logging in with a third party login provider 
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                //AuthenticationMode =AuthenticationMode.Active,
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //LoginPath = new PathString("/#/login"),
                CookieHttpOnly = true,
                CookieName = "boilerplate",
                CookieSecure = CookieSecureOption.SameAsRequest,
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user 
                    // logs in. This is a security feature which is used when you 
                    // change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator
                        .OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user)
                        => user.GenerateUserIdentityAsync(manager, DefaultAuthenticationTypes.ApplicationCookie))
                }
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }

        /// <summary>
        /// Configure OAuth authentication using OWIN middleware
        /// </summary>
        /// <param name="app"></param>
        protected void ConfigureOAuth(IAppBuilder app)
        {

            //var client = IdentityConstants.Clients.Find(x => x.Id == IdentityConstants.AudienceId);

            //use a cookie to temporarily store information about a user logging in with a third party login provider
            // Enable the application to use cookies to authenticate users
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev environment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ApplicationOAuthProvider(),
                //AccessTokenFormat = new CustomJwtFormat(client.AllowedOrigin)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            //Bearer Token
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

            #region JSON Web Token

            ///* JSON Web Token Authentication

            //*/

            //var client = IdentityConstants.Clients.Find(x => x.Id == IdentityConstants.AudienceId);

            //Debug.WriteLine(client);
            //app.UseJwtBearerAuthentication(
            //    new JwtBearerAuthenticationOptions
            //{

            //    AuthenticationMode = AuthenticationMode.Active,
            //    AllowedAudiences = new[] { IdentityConstants.AudienceId },
            //    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
            //        {

            //            new SymmetricKeyIssuerSecurityTokenProvider(client.AllowedOrigin, client.Secret)
            //        },
            //    Provider = new OAuthBearerAuthenticationProvider
            //    {
            //        OnValidateIdentity = context =>
            //            {
            //                context.Ticket.Identity.AddClaim(new System.Security.Claims.Claim("role", IdentityConstants.Roles.Administrator));
            //                return Task.FromResult<object>(null);
            //            }
            //    }
            //});

            #endregion

            //Configure Google External Login
            googleAuthOptions = new GoogleOAuth2AuthenticationOptions()
            {

                ClientId = ServerSettings.Instance.Google_Client_Id,
                ClientSecret = ServerSettings.Instance.Google_Client_Secret,
                Caption = "Protiviti Boilerplate Project SignIn",
                Provider = new GoogleAuthProvider()
            };

            app.UseGoogleAuthentication(googleAuthOptions);

            //Configure Facebook External Login
            facebookAuthOptions = new FacebookAuthenticationOptions()
            {
                AppId = ServerSettings.Instance.Facebook_App_Id,
                AppSecret = ServerSettings.Instance.Facebook_App_Secret,
                Caption = "Protiviti Boilerplate Project SignIn",
                Provider = new FacebookAuthProvider()
            };
            app.UseFacebookAuthentication(facebookAuthOptions);



            //app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            //{
            //    Client_Id = clientId,
            //    Authority = authority,
            //    Post_Logout_Redirect_Uri = postLogoutRedirectUri
            //});

            //activeDirectoryOptions = new WindowsAzureActiveDirectoryBearerAuthenticationOptions
            //{

            //    TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidAudience = ConfigurationManager.AppSettings["Audience"],
            //    },
            //    //Audience = "https://developertenant.onmicrosoft.com/WebUXplusAPI",
            //    //Tenant = "developertenant.onmicrosoft.com",
            //    //AuthenticationType = "OAuth2Bearer",
            //    //Audience = ConfigurationManager.AppSettings["ida:Audience"],
            //    Tenant = ConfigurationManager.AppSettings["ida:Tenant"]

            //};
            //app.UseWindowsAzureActiveDirectoryBearerAuthentication(activeDirectoryOptions);



            /* Enables the application to temporarily store user information when 
            * they are verifying the second factor in the two-factor authentication process.
            */
            app.UseTwoFactorSignInCookie(
                DefaultAuthenticationTypes.TwoFactorCookie,
                TimeSpan.FromMinutes(30));

            /*  Enables the application to remember the second login verification factor such 
            * as phone or email. Once you check this option, your second step of 
            * verification during the login process will be remembered on the device where 
            * you logged in from. This is similar to the RememberMe option when you log in.
            */
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);


        }
    }
}
