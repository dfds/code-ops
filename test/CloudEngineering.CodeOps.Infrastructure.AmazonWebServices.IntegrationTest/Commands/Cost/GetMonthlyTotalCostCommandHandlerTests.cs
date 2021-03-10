using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Cost;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Commands.Cost
{
    [Order(2)]
    public class GetMonthlyTotalCostCommandHandlerTests : IClassFixture<AwsFacadeFixture>
    {
        private readonly AwsFacadeFixture _fixture;

        public GetMonthlyTotalCostCommandHandlerTests(AwsFacadeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CanGetMonthlyTotalCostForAll()
        {
            //Arrange
            var facade = _fixture.Facade;
            var command = new GetMonthlyTotalCostCommand();

            //Act
            var result = await facade.Execute(command);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanGetMonthlyTotalCostForOwnAccount()
        {
            //Arrange
            var facade = _fixture.Facade;
            var command = new GetMonthlyTotalCostCommand()
            {
                AccountIdentifier = "642375522597"
            };

            //Act
            var result = await facade.Execute(command);

            //Assert
            Assert.NotNull(result);
        }

        [Fact(Skip = "It seems like the account we use for the SDK affects the result from the API. We need to use prime and the assume roles for individual accounts.")]
        public async Task CanGetMonthlyTotalCostForOtherCapabilityAccount()
        {
            //Arrange
            var facade = _fixture.Facade;
            var command = new GetMonthlyTotalCostCommand()
            {
                AccountIdentifier = "571914469803"
            };

            //Act
            var result = await facade.Execute(command);

            //Assert
            Assert.NotNull(result);
        }
    }
}
