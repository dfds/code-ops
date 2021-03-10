using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Release;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Release.Definition;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Http.Request.Release.Definition
{
    public class CreateReleaseDefinitionRequestTests
    {
        [Fact]
        public async Task CanBeConstructed()
        {
            //Arrange
            CreateReleaseDefinitionRequest sut;

            //Act
            sut = new CreateReleaseDefinitionRequest("my-org", "my-project", new ReleaseDefinitionDto());

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.0", sut.ApiVersion);
            Assert.Equal(HttpMethod.Post, sut.Method);

            Assert.Equal("https://vsrm.dev.azure.com/my-org/my-project/_apis/release/definitions?api-version=6.0", sut.RequestUri.AbsoluteUri);
            Assert.True(await new StringContent(JsonSerializer.Serialize(new ReleaseDefinitionDto())).ReadAsStringAsync() == await sut.Content.ReadAsStringAsync());
        }
    }
}