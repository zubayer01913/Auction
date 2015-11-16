using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuctionBd.Startup))]
namespace AuctionBd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
