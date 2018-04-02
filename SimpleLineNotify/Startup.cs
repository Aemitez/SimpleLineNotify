using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleLineNotify.Startup))]

namespace SimpleLineNotify
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}