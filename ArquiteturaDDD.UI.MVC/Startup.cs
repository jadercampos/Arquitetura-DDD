using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArquiteturaDDD.UI.MVC.Startup))]
namespace ArquiteturaDDD.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
