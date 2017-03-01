using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiContact.Startup))]
namespace MiContact
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
