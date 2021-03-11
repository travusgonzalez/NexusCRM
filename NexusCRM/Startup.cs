using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NexusCRM.Startup))]
namespace NexusCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
