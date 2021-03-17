using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extension.Configuration;
using CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient;
using XUnit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.IntegrationTest
{
    public class TestGraphClient:IClassFixture<ConfigurationFixture>
    {
        private readonly GraphClientOptions _clientOptions;

        public TestGraphClient(ConfigurationFixture cf)
        {
            // var configuration = ApplicationHelper.GetGraphClientConfiguration();

            var configuration = cf.Configuration;

            var options = configuration.GetSection("GraphClient").Get<GraphClientOptions>();
        }

        [Fact]
        public async Task GraphClientCanListAppRole()
        {
            // Arrange
            var gc = new GraphClient(_clientOptions);

            // Act
            var response = await gc.ListAppRoleRequest("73b80d45-6fd0-4382-825a-eeb3b6f62e88");

            // Assert
            Assert.IsNotEmpty(await response.Content.ReadAsStringAsync());
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GraphClientCanAddAppRole()
        {
            // Arrange
            var configuration = ApplicationHelper.GetGraphClientConfiguration();
            var options = new GraphClientOptions{
                ClientSecret = configuration.ClientSecret
            };
            var gc = new GraphClient(options);

            // Act
            var response = await gc.AddAppRoleRequest("73b80d45-6fd0-4382-825a-eeb3b6f62e88", "43906d0f-beba-467a-88a9-35bae4951ff1", "18d14569-c3bd-439b-9a66-3a2aee01d14f");

            // Assert
            var content = await response.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<AzureAppRoleAssignmentDto>(content);
            Assert.IsNotEmpty(content);
            Assert.True(response.IsSuccessStatusCode);
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
