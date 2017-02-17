using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NgCooking.Startup))]
namespace NgCooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
