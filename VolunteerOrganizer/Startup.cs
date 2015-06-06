using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VolunteerOrganizer.Startup))]
namespace VolunteerOrganizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
