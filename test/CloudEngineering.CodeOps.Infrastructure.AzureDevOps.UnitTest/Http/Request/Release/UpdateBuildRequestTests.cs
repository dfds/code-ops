using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Release;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Release;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Http.Request.Release
{
    public class UpdateReleaseRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            UpdateReleaseRequest sut;

            //Act
            sut = new UpdateReleaseRequest("my-org", "my-project", 1);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.8", sut.ApiVersion);
            Assert.Equal(HttpMethod.Put, sut.Method);

            Assert.Equal("https://vsrm.dev.azure.com/my-org/my-project/_apis/release/releases/1?api-version=6.1-preview.8", sut.RequestUri.AbsoluteUri);
        }

        [Fact]
        public async Task CanBeConstructedWithPayload()
        {
            //Arrange
            UpdateReleaseRequest sut;

            //Act
            sut = new UpdateReleaseRequest("my-org", "my-project", new ReleaseDto());

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.8", sut.ApiVersion);
            Assert.Equal(HttpMethod.Put, sut.Method);
            Assert.Equal("https://vsrm.dev.azure.com/my-org/my-project/_apis/release/releases/0?api-version=6.1-preview.8", sut.RequestUri.AbsoluteUri);
            Assert.True(await new StringContent(JsonSerializer.Serialize(new ReleaseDto())).ReadAsStringAsync() == await sut.Content.ReadAsStringAsync());
        }
    }
}