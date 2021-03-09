using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures
{
    public class AwsFacadeFixture : IDisposable
    {
        private readonly ServiceProviderFixture _serviceFixture = new ServiceProviderFixture();

        public IAwsFacade Facade
        {
            get
            {
                return _serviceFixture.Provider.GetService<IAwsFacade>();
            }
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
            get
            {
                return _serviceFixture.Provider.GetService<IOptions<AwsFacadeOptions>>().Value;
            }
        }

        public AwsFacadeFixture()
        {
            Task.WaitAll(Facade.Execute(new RegisterProfileCommand(TestProfile, Options.AccessKey, Options.SecretKey)));
        }

        public void Dispose()
        {
            Task.WaitAll(Facade.Execute(new UnregisterProfileCommand(TestProfile.Name)));

            _serviceFixture.Dispose();
        }
    }
}
