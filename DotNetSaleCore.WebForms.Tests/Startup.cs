using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetSaleCore.WebForms.Tests.Startup))]
namespace DotNetSaleCore.WebForms.Tests
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
