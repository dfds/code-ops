using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Build.Definition;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Http.Request.Build.Definition
{
    public class CreateDefinitionRequestTests
    {
        [Fact]
        public async Task CanBeConstructed()
        {
            //Arrange
            CreateBuildDefinitionRequest sut;

            //Act
            sut = new CreateBuildDefinitionRequest("my-org", "my-project", new BuildDefinitionDto());

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.7", sut.ApiVersion);
            Assert.Equal(HttpMethod.Post, sut.Method);
            Assert.Equal("https://dev.azure.com/my-org/my-project/_apis/build/definitions?api-version=6.1-preview.7", sut.RequestUri.AbsoluteUri);
            Assert.True(await new StringContent(JsonSerializer.Serialize(new BuildDefinitionDto())).ReadAsStringAsync() == await sut.Content.ReadAsStringAsync());
        }
    }
}