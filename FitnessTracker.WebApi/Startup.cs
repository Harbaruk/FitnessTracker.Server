using FitnessTracker.CompositionRoot;
using FitnessTracker.Operations.Abstraction;
using FitnessTracker.WebApi.Controllers;
using FitnessTracker.WebApi.OAuth;
using FitnessTracker.WebApi.Providers;
using FitnessTracker.WebApi.Providers.Abstraction;
using LightInject;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;
using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(FitnessTracker.WebApi.Startup))]

namespace FitnessTracker.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureWebApi(config);
            ServiceContainer container = ConfigureDependencyResolver(config);

            config
               .EnableSwagger(c => c.SingleApiVersion("v1", "FitnessTracker"))
               .EnableSwaggerUi();

            ConfigureOAuth(app, container);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }


        private static void ConfigureOAuth(IAppBuilder app, IServiceFactory container)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,

                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(7),
                Provider = new SimpleAuthorizationServerProvider(() => container.GetInstance<IAuthenticationOperations>())
            };


            //Configure Google External Login

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

        }

        private static void ConfigureWebApi(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static ServiceContainer ConfigureDependencyResolver(HttpConfiguration httpConfig)
        {
            var container = new ServiceContainer();

            // Other
            Bootstrap.Configure(container);

            // Api
            container.Register<ICurrentUserProvider, CurrentUserProvider>(new PerRequestLifeTime());
            container.Register<IUrlProvider, UrlProvider>(new PerRequestLifeTime());
            container.Register(sf => HttpContext.Current.Request, new PerRequestLifeTime());

            container.RegisterApiControllers(typeof(ApiControllerBase).Assembly);
            container.EnableWebApi(httpConfig);
            return container;
        }

        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
    }
}
