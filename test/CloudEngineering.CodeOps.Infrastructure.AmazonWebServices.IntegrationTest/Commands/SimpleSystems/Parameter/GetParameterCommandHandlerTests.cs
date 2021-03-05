using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Commands.SimpleSystem.Parameter
{
    [Order(2)]
    public class GetParameterCommandHandlerTests : IClassFixture<AwsFacadeFixture>
    {
        private readonly AwsFacadeFixture _fixture;

        public GetParameterCommandHandlerTests(AwsFacadeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetParameterCommandWithInvalidNameThrowsException() 
        {
            //Arrange
            var facade = _fixture.Facade;
            var command = new GetParameterCommand("my-param");

            //Act
            var result = await Assert.ThrowsAsync<AwsFacadeException>(async () => await facade.Execute(command));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetParameterCommandWithValidName()
        {
            //Arrange
            var facade = _fixture.Facade;
            var command = new GetParameterCommand("/managed/deploy/ad-creds");

            //Act
            var result = await facade.Execute(command);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("SecureString", result.ParamType);
        }
    }
}
