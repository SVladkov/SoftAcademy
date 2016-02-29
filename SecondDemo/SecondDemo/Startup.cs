using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecondDemo.Startup))]
namespace SecondDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
