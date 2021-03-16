using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps
{
    public static class DependencyInjection
    {
        public static void AddAzureDevOps(this IServiceCollection services, IConfiguration configuration)
        {
            //Package dependencies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Package dependencies
            services.AddAdoClient(configuration);
        }

        private static void AddAdoClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AdoClientOptions>(configuration.GetSection(AdoClientOptions.AdoClient));

            services.AddTransient<IAdoClient, AdoClient>();
        }
    }
}
