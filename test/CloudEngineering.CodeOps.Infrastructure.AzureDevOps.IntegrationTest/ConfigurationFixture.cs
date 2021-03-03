using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.IntegrationTest.Ado
{
    public class ConfigurationFixture : IDisposable
    {
        public IConfiguration Configuration { get; init; }

        public ConfigurationFixture()
        {
            Configuration = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();
        }

        public void Dispose()
        {
        }
    }
}
