using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Project;
using System.Net.Http;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Project
{
    public class CreateProjectRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            CreateProjectRequest sut;

            //Act
            sut = new CreateProjectRequest("my-org");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.0", sut.ApiVersion);
            Assert.Equal(HttpMethod.Post, sut.Method);
            Assert.Equal("https://dev.azure.com/my-org/_apis/projects?api-version=6.0", sut.RequestUri.AbsoluteUri);
        }
    }
}