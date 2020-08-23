using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MPS.Web.Startup))]
namespace MPS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
