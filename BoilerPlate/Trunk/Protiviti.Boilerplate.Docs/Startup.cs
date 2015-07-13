using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Protiviti.Boilerplate.Docs.Startup))]
namespace Protiviti.Boilerplate.Docs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
