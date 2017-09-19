using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sharp.Web.Test.Startup))]
namespace Sharp.Web.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
