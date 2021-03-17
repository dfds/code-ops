using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Release.Definition;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Release.Definition
{
    public class UpdateReleaseDefinitionRequestTests
    {
        [Fact]
        public async Task CanBeConstructed()
        {
            //Arrange
            UpdateReleaseDefinitionRequest sut;

            //Act
            sut = new UpdateReleaseDefinitionRequest("my-org", "my-project", new ReleaseDefinitionDto());

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.0", sut.ApiVersion);
            Assert.Equal(HttpMethod.Put, sut.Method);

            Assert.Equal("https://vsrm.dev.azure.com/my-org/my-project/_apis/release/definitions?api-version=6.0", sut.RequestUri.AbsoluteUri);
            Assert.True(await new StringContent(JsonSerializer.Serialize(new ReleaseDefinitionDto())).ReadAsStringAsync() == await sut.Content.ReadAsStringAsync());
        }
    }
}