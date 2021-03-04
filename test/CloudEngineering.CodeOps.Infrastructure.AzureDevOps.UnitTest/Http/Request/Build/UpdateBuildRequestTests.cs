using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Build;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Http.Request.Build
{
    public class UpdateBuildRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            UpdateBuildRequest sut;

            //Act
            sut = new UpdateBuildRequest("my-org", "my-project", 1);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.6", sut.ApiVersion);
            Assert.Equal(HttpMethod.Patch, sut.Method);

            Assert.Equal("https://dev.azure.com/my-org/my-project/_apis/build/builds/1?api-version=6.1-preview.6", sut.RequestUri.AbsoluteUri);
        }

        [Fact]
        public async Task CanBeConstructedWithPayload()
        {
            //Arrange
            UpdateBuildRequest sut;

            //Act
            sut = new UpdateBuildRequest("my-org", "my-project", new BuildDto());

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.6", sut.ApiVersion);
            Assert.Equal(HttpMethod.Patch, sut.Method);
            Assert.Equal("https://dev.azure.com/my-org/my-project/_apis/build/builds/0?api-version=6.1-preview.6", sut.RequestUri.AbsoluteUri);
            Assert.True(await new StringContent(JsonSerializer.Serialize(new BuildDto())).ReadAsStringAsync() == await sut.Content.ReadAsStringAsync());
        }
    }
}