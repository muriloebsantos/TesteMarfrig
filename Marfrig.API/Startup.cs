using System;
using System.Threading.Tasks;
using System.Web.Http;
using Marfrig.Application.Mappings;
using Marfrig.CrossCutting.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector.Integration.WebApi;

[assembly: OwinStartup(typeof(Marfrig.API.Startup))]

namespace Marfrig.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            MapperConfig.ConfigureMappings();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(DependencyResolution.GetContainer());
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
