using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordWizApp.Startup))]
namespace WordWizApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
