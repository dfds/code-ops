using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddClient(configuration);
        }

        private static void AddClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AdoClientOptions>(configuration.GetSection(AdoClientOptions.Vsts));

            services.AddTransient<IAdoClient, AdoClient>();
        }
    }
}
