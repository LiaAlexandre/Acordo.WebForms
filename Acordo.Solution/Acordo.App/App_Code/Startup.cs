using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Acordo.App.Startup))]
namespace Acordo.App
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
