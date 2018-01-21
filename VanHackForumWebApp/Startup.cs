using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VanHackForumWebApp.Startup))]
namespace VanHackForumWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
