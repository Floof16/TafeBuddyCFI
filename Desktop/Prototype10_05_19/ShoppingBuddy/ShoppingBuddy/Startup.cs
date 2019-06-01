using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingBuddy.Startup))]
namespace ShoppingBuddy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
