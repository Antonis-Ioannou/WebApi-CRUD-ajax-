using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project.WebApp.Startup))]
namespace Project.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
