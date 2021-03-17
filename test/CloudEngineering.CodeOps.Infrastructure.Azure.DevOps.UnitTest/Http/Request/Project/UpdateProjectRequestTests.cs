using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Project;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Project
{
    public class UpdateProjectRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            UpdateProjectRequest sut;

            //Act
            sut = new UpdateProjectRequest("my-org", "CloudEngineering");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.0", sut.ApiVersion);
            Assert.Equal(HttpMethod.Patch, sut.Method);

            Assert.Equal("https://dev.azure.com/my-org/_apis/projects/CloudEngineering?api-version=6.0", sut.RequestUri.AbsoluteUri);
        }

        [Fact]
        public async Task CanBeConstructedWithPayload()
        {
            //Arrange
            UpdateProjectRequest sut;

            //Act
            sut = new UpdateProjectRequest("my-org", new ProjectDto());

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.0", sut.ApiVersion);
            Assert.Equal(HttpMethod.Patch, sut.Method);

            Assert.Equal($"https://dev.azure.com/my-org/_apis/projects/{Guid.Empty}?api-version=6.0", sut.RequestUri.AbsoluteUri);
            Assert.True(await new StringContent(JsonSerializer.Serialize(new ProjectDto())).ReadAsStringAsync() == await sut.Content.ReadAsStringAsync());
        }
    }
}