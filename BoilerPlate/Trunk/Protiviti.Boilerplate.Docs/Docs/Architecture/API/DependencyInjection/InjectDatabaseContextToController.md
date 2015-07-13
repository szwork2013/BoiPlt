Inject Entity Framework Database Context to a Web API Controller
=

Steps
-
1) Create a constructor that accepts an instance of Entity Framework Database Context and stores in a private member. In the following example, a Breeze Entity Framework Provider is injected to Web API Controller.

    See example Below:

    [BreezeController]
    public class AlbumController : ApiController
    {
        // Initialize entity framework breeze controller
        private EFContextProvider<AlbumContext> _contextProvider;

        public AlbumController(EFContextProvider<AlbumContext> contextProvider)
        {
            this._contextProvider = contextProvider;
        }

        // ~/breeze/Album/Tracks
        [HttpGet]
        public IQueryable<Track> Tracks()
        {
            // http://localhost/Protiviti.Boilerplate.Server/breeze/Album/Tracks
            // http://localhost/Protiviti.Boilerplate.Server/breeze/Album/Tracks?%skip=25&$top=25
            return _contextProvider.Context.Tracks;
        }
    }   

2) Register the Database Context with UnityConfig so it can be injected. In the following example, a Entity Framework Database Context as well as Breeze Entity Framework Provider is registered. Injection Constructor parameters indicates Unity Container to use constructor without parameters.

    See example below:

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<AlbumContext>(new InjectionConstructor());
            container.RegisterType<EFContextProvider<AlbumContext>>(new InjectionConstructor());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }

Benefits
-
1) Auto Instantiation - the injected database context is automatically created by Unity Container.

2) Scope Management - Unity Container manages the scope for injected database context. The context is available as long as the Web API method is in scope.

3) Clean Code - the API implementation is much cleaner.


Other Approaches
-
Use Factory to create database context, but factory approach does not provide all three benefits described above.

Note
-
Even though Entity Framework Database Context is used as an injecting object in this document, but this approach works for injecting any object to any other object.

<p class="updated">Updated on 11/21/2014 by Preiksha Sipani</p>
<p class="reviewed">Reviewed on 11/24/2014 by Preiksha Sipani</p>











