using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcTesting.Startup))]
namespace MvcTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
