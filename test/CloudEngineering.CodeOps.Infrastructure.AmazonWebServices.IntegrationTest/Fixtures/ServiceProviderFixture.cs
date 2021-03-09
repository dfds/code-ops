using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures
{
    public class ServiceProviderFixture : IDisposable
    {
        private readonly ConfigurationFixture _configFixture = new ConfigurationFixture();

        public IServiceProvider Provider { get; init; }

        public ServiceProviderFixture()
        {
            var services = new ServiceCollection();

            services.AddAmazonWebServices(_configFixture.Configuration);

            Provider = services.BuildServiceProvider();

            var options = Provider.GetService<IOptions<AwsFacadeOptions>>();

            Console.WriteLine($"options: {JsonSerializer.Serialize(options)}");
            Console.WriteLine($"env var: {Environment.GetEnvironmentVariable("AWSFACADE__SECRETKEY")}");
        }

        public void Dispose()
        {
            _configFixture.Dispose();
        }
    }
}
