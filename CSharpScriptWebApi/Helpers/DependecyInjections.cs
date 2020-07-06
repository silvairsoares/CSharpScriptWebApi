using CSharpScriptWebApi.Domain.Shared.Services;
using CSharpScriptWebApi.Domain.Shared.ServicesInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpScriptWebApi.Helpers
{
    public class DependecyInjections
    {
        internal static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(IDynamicExpressions), typeof(DynamicExpressions));
        }
    }
}