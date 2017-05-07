using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Praca_dyplomowa.Startup))]
namespace Praca_dyplomowa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
