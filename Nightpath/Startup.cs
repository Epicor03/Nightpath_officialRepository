using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nightpath.Startup))]
namespace Nightpath
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
