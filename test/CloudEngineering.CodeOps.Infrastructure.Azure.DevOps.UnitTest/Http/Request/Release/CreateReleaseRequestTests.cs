using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Release;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Release
{
    public class CreateReleaseRequestTests
    {
        [Fact]
        public async Task CanBeConstructed()
        {
            //Arrange
            CreateReleaseRequest sut;

            //Act
            sut = new CreateReleaseRequest("my-org", "my-project", new ReleaseDto());

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.8", sut.ApiVersion);
            Assert.Equal(HttpMethod.Post, sut.Method);

            Assert.Equal("https://vsrm.dev.azure.com/my-org/my-project/_apis/release/releases?api-version=6.1-preview.8", sut.RequestUri.AbsoluteUri);
            Assert.True(await new StringContent(JsonSerializer.Serialize(new ReleaseDto())).ReadAsStringAsync() == await sut.Content.ReadAsStringAsync());
        }
    }
}