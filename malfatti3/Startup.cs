using Microsoft.Owin;
using Owin;
using malfatti;

[assembly: OwinStartupAttribute(typeof(malfatti.Startup))]
namespace malfatti
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
