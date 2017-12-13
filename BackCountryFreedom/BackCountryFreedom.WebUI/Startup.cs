using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackCountryFreedom.WebUI.Startup))]
namespace BackCountryFreedom.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
