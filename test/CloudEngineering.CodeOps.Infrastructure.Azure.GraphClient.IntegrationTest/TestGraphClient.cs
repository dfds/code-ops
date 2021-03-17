using CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.IntegrationTest.Fixtures;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.IntegrationTest
{
    public class TestGraphClient : IClassFixture<ConfigurationFixture>
    {
        private readonly GraphClientOptions _clientOptions;

        public TestGraphClient(ConfigurationFixture cf)
        {
            _clientOptions = cf.Configuration.GetSection("GraphClient").Get<GraphClientOptions>();
        }

        [Fact(Skip = "TODO: TOBAN")]
        public async Task GraphClientCanListAppRole()
        {
            // Arrange
            var sut = new GraphClient(_clientOptions);

            // Act
            var response = await sut.ListAppRoleRequest("73b80d45-6fd0-4382-825a-eeb3b6f62e88");

            // Assert
            Assert.NotEmpty(await response.Content.ReadAsStringAsync());
            // Assert.True(response.IsSuccessStatusCode);
        }

        [Fact(Skip="TODO: TOBAN")]
        public async Task GraphClientCanAddAppRole()
        {
            // Arrange
            var sut = new GraphClient(_clientOptions);

            // Act
            var response = await sut.AddAppRoleRequest("73b80d45-6fd0-4382-825a-eeb3b6f62e88", "43906d0f-beba-467a-88a9-35bae4951ff1", "18d14569-c3bd-439b-9a66-3a2aee01d14f");

            // Assert
            var content = await response.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<AzureAppRoleAssignmentDto>(content);
            Assert.NotEmpty(content);
            // Assert.True(response.IsSuccessStatusCode);
        }

        // [Test]
        // [Explicit]
        // public async Task GraphClientCanRemoveAppRole()
        // {
        //     // Arrange
        //     var gc = new GraphClient(_clientOptions);

        //     // Act
        //     var response = await gc.RemoveAppRoleRequest("73b80d45-6fd0-4382-825a-eeb3b6f62e88");

        //     // Assert
        //     Assert.IsNotEmpty(await response.Content.ReadAsStringAsync());
        //     Assert.True(response.IsSuccessStatusCode);
        // }
    }
}
