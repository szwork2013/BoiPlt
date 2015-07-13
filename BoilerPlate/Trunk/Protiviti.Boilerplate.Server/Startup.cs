using Microsoft.Owin;
using Owin;
using Protiviti.Boilerplate.Server.Migrations;
using Protiviti.Boilerplate.Server.Api.Search;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Diagnostics;
using Protiviti.Boilerplate.Server.Api.Account;
using System.Linq;

[assembly: OwinStartup(typeof(Protiviti.Boilerplate.Server.Startup))]
namespace Protiviti.Boilerplate.Server
{
    public partial class Startup
    {
        /// <summary>
        /// Configure startup settings for application
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {

            HttpConfiguration config = new HttpConfiguration();

            UnityConfig.RegisterComponents();

            LoadClients();

            ConfigureAuth(app);

            ConfigureWebApi(config);

            //Enabling Cross Origin Resource Request feature
            app.UseCors(CorsOptions.AllowAll);

            //Configure Owin pipeline for web api
            app.UseWebApi(config);

            //Configuring Web Api documentation
            ConfigureApiDocumentation(config);

            app.UseWelcomePage("/welcome");

            app.UseErrorPage(new ErrorPageOptions()
            {
                //Shows the OWIN environment dictionary keys and values. This detail is enabled by default if you are running your app from VS unless disabled in code. 
                ShowEnvironment = true,
                //Hides cookie details
                ShowCookies = false,
                //Shows the lines of code throwing this exception. This detail is enabled by default if you are running your app from VS unless disabled in code. 
                ShowSourceCode = false,
                ShowExceptionDetails = true,
                ShowHeaders = true,
                ShowQuery = true,

            });
            DatabaseInitializer.InitializeDatabases();
            SearchInitializer.Initialize();
        }


        private void LoadClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (IdentityConstants.Clients == null)
                {
                    IdentityConstants.Clients = ctx.Clients.ToList();
                }
            }
        }

    }
}
