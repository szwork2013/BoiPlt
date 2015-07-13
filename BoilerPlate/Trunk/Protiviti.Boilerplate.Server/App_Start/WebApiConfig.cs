#define DEBUG 
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Protiviti.Boilerplate.Server.Logging;
using Protiviti.Boilerplate.Server.ExceptionHandling;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Protiviti.Boilerplate.Server.Api.ApplicationWizard;
using Microsoft.Owin.Security.OAuth;

namespace Protiviti.Boilerplate.Server
{
    public static class WebApiConfig
    {
        /// <summary>
        /// Configuring web api properties
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static HttpConfiguration Register(HttpConfiguration config)
        {

#if DEBUG
           config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
#else
           config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never;
#endif

            config.EnableSystemDiagnosticsTracing();
            config.Services.Replace(typeof(System.Web.Http.Tracing.ITraceWriter), new SlabTraceWriter());

            /*
            * Enables suppression of the host's default authentication.
            * Remarks: When the host's default authentication is suppressed, the current principal is set to anonymous upon 
            * entering the HttpServer's first message handler. As a result, any default authentication performed by 
            * the host is ignored. The remaining pipeline within the HttpServer, including IAuthenticationFilters, 
            * is then the exclusive authority for authentication.
            */

            config.SuppressDefaultHostAuthentication();
            // Configure Web Api to use only bearer token authentication.
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Configuring web api routes
            config.MapHttpAttributeRoutes();

           // config.Routes.MapHttpRoute(
           //    name: "DefaultApi",
           //    routeTemplate: "api/{controller}/{id}",
           //    defaults: new { id = RouteParameter.Optional }
           //);

            config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());


            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =   new CamelCasePropertyNamesContractResolver();

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Application>("Applications");
            builder.EntitySet<Applicant>("Applicants");
            builder.EntitySet<Invoice>("Invoices");
            builder.EntitySet<Program>("Programs");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            return config;
        }
    }
}
