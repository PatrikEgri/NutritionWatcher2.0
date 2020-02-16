using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NutritionWatcher2._0.Startup))]
namespace NutritionWatcher2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
