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
            Console.WriteLine($"appsettings.json is in root of base dir: {File.Exists(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json")}");
            Console.WriteLine($"Content of appsettings.jsonin root of base dir: {File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json")}");
            Console.WriteLine($"Env var: {Environment.GetEnvironmentVariable("AwsFacade_SecretKey")}");
            Console.WriteLine($"Env var2: {Environment.GetEnvironmentVariable("AwsFacade__SecretKey")}");
            Console.WriteLine($"Env var3: {Environment.GetEnvironmentVariable("$AWSFACADE__SECRETKEY")}");

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
