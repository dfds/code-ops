using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine($"Env var: " + (Environment.GetEnvironmentVariables() as Dictionary<string, string>).Aggregate(new StringBuilder(),
              (sb, kvp) => sb.AppendFormat("{0}{1} = {2}",
                           sb.Length > 0 ? ", " : "", kvp.Key, kvp.Value),
              sb => sb.ToString()));

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
