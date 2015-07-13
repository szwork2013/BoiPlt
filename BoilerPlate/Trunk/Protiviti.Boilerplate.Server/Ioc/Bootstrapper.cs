using Autofac;
using Microsoft.AspNet.Identity;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity.EntityFramework;
using Protiviti.Boilerplate.Server;
using System.Data.Entity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Protiviti.Boilerplate.Server.Api.Employee;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Protiviti.Boilerplate.Server.Logging;
using System.Diagnostics.Tracing;
using System.Data.Entity.Infrastructure.Interception;
using Repository.Pattern.Ef6.Factories;
using Protiviti.Data.Logging;
using Protiviti.Boilerplate.Server.Api.Account;
using Breeze.ContextProvider.EF6;

namespace Protiviti.Boilerplate.Server
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            //Semantic Logging
            RegisterLogger();
            RegisterEFLogger();
            //EF
            RegisterEFDatabaseExtensions();
        }


        public static IContainer ConfigureWebApiContainer()
        {

            Configure();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<EmployeeContext>().As<IDataContextAsync>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<ProtivitiContextProvider<EmployeeContext>>().As<IBreezeUnitofWorkAsync>().AsImplementedInterfaces().InstancePerRequest();
            //containerBuilder.Register(c=> new EFContextProvider<ApplicationDbContext>()).As<EFContextProvider<ApplicationDbContext>>().InstancePerRequest();

            //containerBuilder.RegisterType<BaseController>().PropertiesAutowired();
            containerBuilder.Register(c => new RepositoryProvider(new RepositoryFactories())).As<IRepositoryProvider>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<Repository<Employee>>().As<IRepositoryAsync<Employee>>().AsImplementedInterfaces().InstancePerRequest();

            // containerBuilder.RegisterType<EmployeeService>().As<IEmployeeService>().AsImplementedInterfaces().InstancePerRequest();// InstancePerApiRequest();

            containerBuilder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())
            {
                /*Avoids UserStore invoking SaveChanges on every actions.*/
                //AutoSaveChanges = false
            })).As<UserManager<ApplicationUser>>().InstancePerRequest();

            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly()).PropertiesAutowired();
            IContainer container = containerBuilder.Build();
            return container;
            
        }

        private static void RegisterLogger()
        {
            var listener = new ObservableEventListener();
            listener.EnableEvents(WebApiTracing.Log, EventLevel.LogAlways, Keywords.All);

            listener.LogToConsole();
            listener.LogToFlatFile("test.log");
            listener.LogToWindowsAzureTable(instanceName: "Protiviti", connectionString: "UseDevelopmentStorage=true");
        }
        private static void RegisterEFLogger()
        {
            var listener = new ObservableEventListener();
            listener.EnableEvents(EFLogging.Logger, EventLevel.LogAlways, Keywords.All);

            listener.LogToFlatFile("EFSqls.log");
            listener.LogToWindowsAzureTable(instanceName: "Protiviti", connectionString: "UseDevelopmentStorage=true",tableAddress:"EFSqls");
        }

        private static void RegisterEFDatabaseExtensions()
        {
            DbInterception.Add(new EFDbInterceptorLogging());
        }

        
    }
}