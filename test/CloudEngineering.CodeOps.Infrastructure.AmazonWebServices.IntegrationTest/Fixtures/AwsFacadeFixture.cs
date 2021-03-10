using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures
{
    public class AwsFacadeFixture : IDisposable
    {
        private readonly ServiceProviderFixture _serviceFixture = new ServiceProviderFixture();

        public IAwsFacade Facade
        {
            get;
            set;
        }

        internal IAwsProfile TestProfile
        {
            get
            {
                return Options.Impersonate;
            }
        }

        internal AwsFacadeOptions Options
        {
            get; set;
        }

        public AwsFacadeFixture() 
        {
            Facade = _serviceFixture.Provider.GetService<IAwsFacade>();
            Options = _serviceFixture.Provider.GetService<IOptions<AwsFacadeOptions>>().Value;
        }

        public void Dispose()
        {
            Facade.Dispose();

            _serviceFixture.Dispose();
        }
    }
}
