using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;

namespace CSharpScriptWebApi.Helpers
{
    public static class SwaggerSetup
    {
        internal static void ConfigureSwaggerDoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOpenApiDocument(config =>
            {
                config.Version = "v1";

                config.AllowReferencesWithProperties = true;
                config.Title = ".Net Core API, for demonstration of 'Microsoft.CodeAnalysis.CSharp.Scripting'";

                config.Description = ".Net Core API, for demonstration of 'Microsoft.CodeAnalysis.CSharp.Scripting'";
            });
        }

        internal static void ConfigureSwaggerUI(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Ativa o middleware para veicular o Swagger gerado como um terminal JSON.
            app.UseOpenApi();

            // Esta opção possibilita a inclusão de css e js personalizados na UI do Swagger
            app.UseStaticFiles();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwaggerUi3(config => config.TransformToExternalPath = (internalUiRoute, request) =>
            {
                config.Path = "/swagger";

                //Settings for IIS
                if (internalUiRoute.StartsWith("/") == true && internalUiRoute.StartsWith(request.PathBase) == false)
                {
                    return request.PathBase + internalUiRoute;
                }
                else
                {
                    return internalUiRoute;
                }
            });
        }
    }
}
