using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures;
using Xunit;
using Xunit.Extensions.Ordering;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Commands.SimpleSystem.Parameter
{
    [Order(2)]
    public class AddOrUpdateParameterCommandHandlerTests : IClassFixture<AwsFacadeFixture>
    {
        private readonly AwsFacadeFixture _fixture;

        public AddOrUpdateParameterCommandHandlerTests(AwsFacadeFixture fixture)
        {
            _fixture = fixture;
        }
    }
}
