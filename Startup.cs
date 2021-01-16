using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Initiere.Startup))]
namespace Initiere
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
