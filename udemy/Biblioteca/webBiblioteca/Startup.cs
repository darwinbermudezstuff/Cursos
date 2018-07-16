using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webBiblioteca.Startup))]
namespace webBiblioteca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
