using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFUnitOfWork.Startup))]
namespace EFUnitOfWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
