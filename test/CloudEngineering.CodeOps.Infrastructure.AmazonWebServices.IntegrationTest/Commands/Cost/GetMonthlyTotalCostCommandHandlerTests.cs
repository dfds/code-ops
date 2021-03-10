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
            using var facade = _fixture.Facade;
            var command = new GetMonthlyTotalCostCommand();

            //Act
            var result = await facade.Execute(command);

            //Assert
            Assert.NotNull(result);
        }
    }
}
