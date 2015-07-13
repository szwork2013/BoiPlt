using System.Web.Http;
using Protiviti.Boilerplate.Server;
using WebActivatorEx;
using Swashbuckle.Application;
using System.Net.Http;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Protiviti.Boilerplate.Server
{
    public class SwaggerConfig
    {
        /// <summary>
        /// Configure swagger features
        /// </summary>
        public static void Register()
        {
            Swashbuckle.Bootstrapper.Init(GlobalConfiguration.Configuration);

            // NOTE: If you want to customize the generated swagger or UI, use SwaggerSpecConfig and/or SwaggerUiConfig here ...

            SwaggerSpecConfig.Customize(c =>
            {
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.ResolveBasePathUsing((req) => GetBasePath(req));
            });
        }

        /// <summary>
        /// Returns the base url of the request including virtual directory if any
        /// </summary>
        /// <param name="request">Request message</param>
        /// <returns>Base Url</returns>
        public static string GetBasePath(HttpRequestMessage request)
        {
            string baseUrl = request.RequestUri.Scheme + "://" + request.RequestUri.Host;
            if (!string.IsNullOrWhiteSpace(request.GetRequestContext().VirtualPathRoot))
            {
                baseUrl = baseUrl + request.GetRequestContext().VirtualPathRoot;
            }
            return baseUrl;
        }

        /// <summary>
        /// Get the XML file path
        /// </summary>
        /// <returns></returns>
        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\Protiviti.Boilerplate.Server.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}