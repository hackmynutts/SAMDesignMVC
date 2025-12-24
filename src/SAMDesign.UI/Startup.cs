using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAMDesign.UI.Startup))]
namespace SAMDesign.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
