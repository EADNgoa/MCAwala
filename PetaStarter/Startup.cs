using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cavala.Startup))]
namespace Cavala
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
