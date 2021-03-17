using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Release;
using System.Net.Http;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Release
{
    public class GetReleaseRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            GetReleaseRequest sut;

            //Act
            sut = new GetReleaseRequest("my-org", "my-project", 1);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.8", sut.ApiVersion);
            Assert.Equal(HttpMethod.Get, sut.Method);

            Assert.Equal("https://vsrm.dev.azure.com/my-org/my-project/_apis/release/releases/1?api-version=6.1-preview.8", sut.RequestUri.AbsoluteUri);
        }
    }
}