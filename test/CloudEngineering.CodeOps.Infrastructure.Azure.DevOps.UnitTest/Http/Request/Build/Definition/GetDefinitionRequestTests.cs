using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build.Definition;
using System.Net.Http;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Build.Definition
{
    public class GetDefinitionRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            GetBuildDefinitionRequest sut;

            //Act
            sut = new GetBuildDefinitionRequest("my-org", "my-project", 1);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.7", sut.ApiVersion);
            Assert.Equal(HttpMethod.Get, sut.Method);
            Assert.Equal("https://dev.azure.com/my-org/my-project/_apis/build/definitions/1?api-version=6.1-preview.7", sut.RequestUri.AbsoluteUri);
        }
    }
}