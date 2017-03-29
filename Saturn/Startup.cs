using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Saturn.Startup))]
namespace Saturn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
