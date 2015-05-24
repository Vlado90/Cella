using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cella.Web.Startup))]
namespace Cella.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
