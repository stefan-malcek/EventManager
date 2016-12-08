using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventManager.PL.Startup))]
namespace EventManager.PL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
