using Breeze.ContextProvider.EF6;
using Microsoft.Practices.Unity;
using Protiviti.Boilerplate.Server.Api.Account;
using Protiviti.Boilerplate.Server.Api.Album;
using Protiviti.Boilerplate.Server.Api.ApplicationWizard;
using System.Web.Http;
using Unity.WebApi;

namespace Protiviti.Boilerplate.Server
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ApplicationWizardContext>(new InjectionConstructor());
            container.RegisterType<EFContextProvider<ApplicationWizardContext>>(new InjectionConstructor());
            container.RegisterType<AlbumContext>(new InjectionConstructor());
            container.RegisterType<EFContextProvider<AlbumContext>>(new InjectionConstructor());
            //container.RegisterType<ApplicationDbContext>(new InjectionConstructor());
            //container.RegisterType<EFContextProvider<ApplicationDbContext>>(new InjectionConstructor());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}