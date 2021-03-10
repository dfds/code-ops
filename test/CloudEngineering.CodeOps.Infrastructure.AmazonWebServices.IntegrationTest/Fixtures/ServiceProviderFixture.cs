using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            
            services.AddTransient<ServiceFactory>(p => p.GetService);
            services.AddSingleton<IMediator>(p => new Mediator(p.GetService<ServiceFactory>()));

            Provider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
            _configFixture.Dispose();
        }
    }
}
