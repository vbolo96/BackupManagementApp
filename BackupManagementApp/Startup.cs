using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackupManagementApp.Startup))]
namespace BackupManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
