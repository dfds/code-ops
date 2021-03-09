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
            Console.WriteLine($"ConfigFixture base dir: {AppDomain.CurrentDomain.BaseDirectory}");
            Console.WriteLine($"AppSettings.json is in root of base dir: {File.Exists(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json")}");

            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly());

            Configuration = builder.Build();
        }

        public void Dispose()
        {
        }
    }
}
