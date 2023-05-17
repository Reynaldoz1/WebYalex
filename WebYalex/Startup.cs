using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebYalex.StartupOwin))]

namespace WebYalex
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
