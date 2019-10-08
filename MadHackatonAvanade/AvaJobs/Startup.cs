using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AvaJobs.Startup))]
namespace AvaJobs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
