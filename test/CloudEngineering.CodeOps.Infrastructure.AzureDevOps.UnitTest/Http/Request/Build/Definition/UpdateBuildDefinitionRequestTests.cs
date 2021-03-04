using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Build;
using System.Net.Http;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Http.Request.Build.Definition
{
    public class UpdateBuildDefinitionRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            UpdateBuildDefinitionRequest sut;

            //Act
            sut = new UpdateBuildDefinitionRequest("my-org", "my-project", 1);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.7", sut.ApiVersion);
            Assert.Equal(HttpMethod.Put, sut.Method);

            Assert.Equal("https://dev.azure.com/my-org/my-project/_apis/build/builds/definitions/1?api-version=6.1-preview.7", sut.RequestUri.AbsoluteUri);
        }
    }
}