using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures
{
    public class ConfigurationFixture : IDisposable
    {
        public IConfiguration Configuration { get; init; }

        public ConfigurationFixture()
        {
            Console.WriteLine($"ConfigFixture base dir: {AppDomain.CurrentDomain.BaseDirectory}");

            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly());

            Configuration = builder.Build();

            Console.WriteLine($"AwsFacade section: {Configuration.GetSection("AwsFacade").Value}");
        }

        public void Dispose()
        {
        }
    }
}
