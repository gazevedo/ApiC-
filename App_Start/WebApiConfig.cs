using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
             // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Rota padrão
            string defaultRoutePrefix = String.Format("api/v{0}/", ConfigurationManager.AppSettings["api_version"]);
            defaultRoutePrefix += "{controller}/{action}/{id}";

            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);

            config.Routes.MapHttpRoute(
                name: "ApiFolhaPagamento",
                routeTemplate: defaultRoutePrefix,
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Filters.Add(new Shared.Filters.AuthorizeFilter());
            GlobalConfiguration.Configuration.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));
        }
    }
}
