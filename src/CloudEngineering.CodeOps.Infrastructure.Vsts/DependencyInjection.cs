using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddVsts(configuration);
        }

        private static void AddVsts(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<VstsClientOptions>(configuration.GetSection(VstsClientOptions.Vsts));

            services.AddTransient<IVstsClient, VstsClient>();
        }
    }
}
