using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KNGSoftware.Startup))]
namespace KNGSoftware
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
