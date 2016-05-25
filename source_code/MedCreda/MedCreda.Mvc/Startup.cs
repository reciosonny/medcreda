using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedCreda.Mvc.Startup))]
namespace MedCreda.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
