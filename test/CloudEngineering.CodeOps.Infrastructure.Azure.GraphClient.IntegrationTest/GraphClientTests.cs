using CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.IntegrationTest.Fixtures;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.IntegrationTest
{
    public class GraphClientTests : IClassFixture<ConfigurationFixture>
    {
        private readonly GraphClientOptions _clientOptions;

        public GraphClientTests(ConfigurationFixture cf)
        {
            _clientOptions = cf.Configuration.GetSection("GraphClient").Get<GraphClientOptions>();
        }

        [Fact]
        public async Task GraphClientCanListAppRole()
        {
            // Arrange
            var sut = new GraphClient(_clientOptions);

            // Act
            var response = await sut.ListAppRoleRequest("73b80d45-6fd0-4382-825a-eeb3b6f62e88");

            // Assert
            Assert.True(response.StatusCode != System.Net.HttpStatusCode.NotFound);
            Assert.True(response.StatusCode != System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GraphClientCanAddAppRole()
        {
            // Arrange
            var sut = new GraphClient(_clientOptions);

            // Act
            var response = await sut.AddAppRoleRequest("73b80d45-6fd0-4382-825a-eeb3b6f62e88", "43906d0f-beba-467a-88a9-35bae4951ff1", "18d14569-c3bd-439b-9a66-3a2aee01d14f");
            var content = await response.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<AzureAppRoleAssignmentDto>(content);

            // Assert
            Assert.True(response.StatusCode != System.Net.HttpStatusCode.NotFound);
            Assert.True(response.StatusCode != System.Net.HttpStatusCode.BadRequest);
        }
    }
}
