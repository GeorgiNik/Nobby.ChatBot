using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using Nobby.ChatBot.Models;

namespace Nobby.ChatBot
{
    public static class WebApiConfig
    {
        public static IntentsList IntentHandlers { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            IntentHandlers = new IntentsList
            {
                { "YesIntent", Handlers.YesIntent.Process },
                { "ReservationsIntent", Handlers.ReservationsIntent.Process },
                { "DefaultWelcomeIntent", Handlers.WelcomeIntent.Process }
            };

            // Json settings
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
