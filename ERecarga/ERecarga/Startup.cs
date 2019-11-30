using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERecarga.Startup))]
namespace ERecarga
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
