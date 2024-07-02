using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using ApiFolhaPagamento;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ApiFolhaPagamento
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                    .EnableSwagger(c =>
                    { 
                        c.Schemes(new[] { "http", "https" });
                         
                        c.SingleApiVersion("v0", "ApiFolhaPagamento"); 
                        c.ApiKey("Authorization")
                            .Description("API Key Authentication")
                            .Name("Authorization")
                            .In("header"); 
                        c.IncludeXmlComments("C:\\inetpub\\wwwroot\\ApiFolhaPagamento\\ApiFolhaPagamento.XML"); 
                    })
                    .EnableSwaggerUi(c =>
                    { 
                        c.InjectStylesheet(thisAssembly, "ApiFolhaPagamento.CustomSwagger.ParkTheme.css");
                         
                        c.InjectJavaScript(thisAssembly, "ApiFolhaPagamento.CustomSwagger.alterHeader.js"); 
                        c.EnableApiKeySupport("Authorization", "header");
                    });
        }
    }
}
