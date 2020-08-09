using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OsobyZaginioneAPP.Startup))]
namespace OsobyZaginioneAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
