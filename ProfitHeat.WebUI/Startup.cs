using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProfitHeat.WebUI.Startup))]
namespace ProfitHeat.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
