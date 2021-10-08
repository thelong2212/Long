using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_PA.Startup))]
namespace Web_PA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
