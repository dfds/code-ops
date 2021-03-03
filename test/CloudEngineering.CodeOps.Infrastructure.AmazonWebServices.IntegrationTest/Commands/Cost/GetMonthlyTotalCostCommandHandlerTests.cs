using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Cost;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Commands.Cost
{
    public class GetMonthlyTotalCostCommandHandlerTests : IClassFixture<ServiceProviderFixture>
    {
        private readonly ServiceProviderFixture _fixture;

        public GetMonthlyTotalCostCommandHandlerTests(ServiceProviderFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CanGetMonthlyTotalCostForAll() 
        {
            //Arrange
            var command = new GetMonthlyTotalCostCommand();
            var options = _fixture.Provider.GetService<IOptions<AwsFacadeOptions>>();
            var sut = _fixture.Provider.GetService<IAwsFacade>();

            //Act
            await sut.Execute(new RegisterProfileCommand(options.Value.Impersonate, options.Value.AccessKey, options.Value.SecretKey));

            var result = await sut.Execute(command);

            await sut.Execute(new UnregisterProfileCommand(options.Value.Impersonate.Name));

            //Assert
            Assert.NotNull(result);
        }
    }
}
