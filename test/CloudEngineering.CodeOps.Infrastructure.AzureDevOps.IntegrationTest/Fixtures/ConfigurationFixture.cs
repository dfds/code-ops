using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.IntegrationTest.Fixtures
{
    public class ConfigurationFixture : IDisposable
    {
        public IConfiguration Configuration { get; init; }

        public ConfigurationFixture()
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();
        }

        public void Dispose()
        {
        }
    }
}
