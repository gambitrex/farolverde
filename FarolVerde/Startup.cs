using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarolVerde.Startup))]
namespace FarolVerde
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
