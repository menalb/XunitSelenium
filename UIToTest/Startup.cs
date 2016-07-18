using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UIToTest.Startup))]
namespace UIToTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
