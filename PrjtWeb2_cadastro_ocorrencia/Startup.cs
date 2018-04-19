using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrjtWeb2_cadastro_ocorrencia.Startup))]
namespace PrjtWeb2_cadastro_ocorrencia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
