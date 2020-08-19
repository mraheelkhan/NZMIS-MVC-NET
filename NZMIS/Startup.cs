using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NZMIS.Startup))]
namespace NZMIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
