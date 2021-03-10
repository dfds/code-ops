using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices
{
    public static class DependencyInjection
    {
        public static void AddAmazonWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Framework dependencies
            services.AddLogging();

            //Package dependencies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddFacade(configuration);
        }

        private static void AddFacade(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AwsFacadeOptions>(configuration.GetSection(AwsFacadeOptions.AwsFacade));

            services.AddTransient<IAwsCredentialResolver, AwsCredentialResolver>();
            services.AddTransient<IAwsClientFactory, AwsClientFactory>();
            services.AddTransient<IAwsFacade, AwsFacade>();
        }
    }
}
