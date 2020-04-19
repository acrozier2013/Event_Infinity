using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Event_Infinity.Startup))]
namespace Event_Infinity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
