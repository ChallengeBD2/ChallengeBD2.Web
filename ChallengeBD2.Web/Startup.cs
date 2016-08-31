using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChallengeBD2.Web.Startup))]
namespace ChallengeBD2.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
