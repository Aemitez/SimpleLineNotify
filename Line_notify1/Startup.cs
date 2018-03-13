using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Line_notify1.Startup))]
namespace Line_notify1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
