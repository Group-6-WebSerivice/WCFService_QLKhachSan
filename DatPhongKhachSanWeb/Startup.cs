using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatPhongKhachSanWeb.Startup))]
namespace DatPhongKhachSanWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
