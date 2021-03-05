using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest
{
    public class AwsFacadeTests : IClassFixture<ServiceProviderFixture>
    {
        private readonly ServiceProviderFixture _fixture;

        public AwsFacadeTests(ServiceProviderFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanRegisterDefaultProfile()
        {
            //Arrange
            var sut = _fixture.Provider.GetService<IAwsFacade>();
            var options = _fixture.Provider.GetService<IOptions<AwsFacadeOptions>>();
            var cmd = new RegisterProfileCommand(options.Value.Impersonate, options.Value.AccessKey, options.Value.SecretKey);

            //Act
            var result = sut.Execute(cmd);

            //Assert
            Assert.False(result.IsFaulted);
        }

        [Fact]
        public void CanUnregisterDefaultProfile()
        {
            //Arrange
            var sut = _fixture.Provider.GetService<IAwsFacade>();
            var options = _fixture.Provider.GetService<IOptions<AwsFacadeOptions>>();
            var cmd = new UnregisterProfileCommand(options.Value.Impersonate.Name);

            //Act
            var result = sut.Execute(cmd);

            //Assert
            Assert.False(result.IsFaulted);
        }
    }
}
