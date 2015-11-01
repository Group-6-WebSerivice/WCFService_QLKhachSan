using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyKhachSanWeb.Startup))]
namespace QuanLyKhachSanWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
