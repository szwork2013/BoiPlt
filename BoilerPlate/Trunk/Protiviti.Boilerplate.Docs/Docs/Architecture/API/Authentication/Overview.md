Security Architecture
=====================
Security on server project is implemented using OWIN middleware components. [Owin](owin) provides different security components to use depending on need. we have currently implemented the following complements to enable the authentication in system

* Internal login: Use it's [OAuth](OAuthSecurityOverview) middleware component with bearer token 
* Social login: Uses its Google and Facebook component. 

Below code shows how to configure different security components

            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {

                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ApplicationOAuthProvider(),
                //RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

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


###Resources

* [OWIN](http://owin.org/)
* [OWIN and Katana](http://www.asp.net/aspnet/overview/owin-and-katana)
* [Getting Started With Katana](http://msdn.microsoft.com/en-us/magazine/dn451439.aspx)



### Prerequisites
* Visual Studio 2013 templates by default come with OWIN middle setup for you. When you install new project by selecting "Asp.Net Web Application" web template, 
you get following 2 files created

* "Startup.cs" at the root of the project
* "Startup.Auth.cs" under the "App_Start" folder. This file contains the OWIN security middleware component configuration.

By convention, "Startup.cs" is first file to execute in the application life cycle, so if you want you can get rid of the "Global.asax" file.


###Important Notes
* As a part recent decision, Microsoft is going to end the .Net 4.0 support by 2016. Hence all latest component only support .Net 4.5

<p class="updated">Updated on 11/21/2014 by Ajay Singh</p>
<p class="reviewed">Reviewed on 11/24/2014 by Ajay Singh</p>
