using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Fixtures
{
    public class ServiceProviderFixture : IDisposable
    {
        public IServiceProvider Provider { get; init; }

        public ServiceProviderFixture()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();

            var services = new ServiceCollection();

            services.AddAmazonWebServices(config);

            Provider = services.BuildServiceProvider();
        }

        public void Dispose()
        {

        }
    }
}
