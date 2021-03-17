using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build;
using System.Net.Http;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Build
{
    public class GetChangesBetweenBuildsTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            GetChangesBetweenBuilds sut;

            //Act
            sut = new GetChangesBetweenBuilds("my-org", "my-project", 1, 2);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.2", sut.ApiVersion);
            Assert.Equal(HttpMethod.Get, sut.Method);

            Assert.Equal("https://dev.azure.com/my-org/my-project/_apis/build/changes?api-version=6.1-preview.2&fromBuildId=1&toBuildId=2", sut.RequestUri.AbsoluteUri);
        }
    }
}