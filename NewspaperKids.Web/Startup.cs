using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewspaperKids.Web.Startup))]
namespace NewspaperKids.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
