using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.IntegrationTest.Fixtures
{
    public class ConfigurationFixture : IDisposable
    {
        public IConfiguration Configuration { get; init; }

        public ConfigurationFixture()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly());

            Configuration = builder.Build();
        }

        public void Dispose()
        {
        }
    }
}
