using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TTrackerDemo.Startup))]
namespace TTrackerDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
