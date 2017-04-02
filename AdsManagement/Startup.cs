using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdsManagement.Startup))]
namespace AdsManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
