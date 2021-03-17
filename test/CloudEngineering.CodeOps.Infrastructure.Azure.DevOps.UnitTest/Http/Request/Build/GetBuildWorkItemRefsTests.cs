using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build;
using System.Net.Http;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Build
{
    public class GetBuildWorkItemRefsTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            GetBuildWorkItemRefs sut;

            //Act
            sut = new GetBuildWorkItemRefs("my-org", "my-project", 1);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.2", sut.ApiVersion);
            Assert.Equal(HttpMethod.Get, sut.Method);

            Assert.Equal("https://dev.azure.com/my-org/my-project/_apis/build/builds/1/workitems?api-version=6.1-preview.2", sut.RequestUri.AbsoluteUri);
        }
    }
}