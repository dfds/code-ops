using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures
{
    public class ConfigurationFixture : IDisposable
    {
        public IConfiguration Configuration { get; init; }

        public ConfigurationFixture()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly());

            Configuration = builder.Build();
        }

        public void Dispose()
        {
        }
    }
}
