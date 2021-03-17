using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Build;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Release;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters;
using Moq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Mapping.Converters
{
    public class AdoEventToAdoDtoConverterTests
    {
        [Fact]
        public void CanConvertBuildCompletedEventToBuildDto()
        {
            //Arrange
            var mockAdoClient = new Mock<IAdoClient>();
            var fakeBuild = new BuildDto() { Id = 1, Project = new ProjectDto() { Id = new System.Guid("3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1") } };
            var fakeBuildEvent = new BuildCompletedEvent()
            {
                EventType = BuildCompletedEvent.EventIdentifier,
                Resource = JsonDocument.Parse("{\"id\": 1}").RootElement,
                ResourceContainers = JsonDocument.Parse("{\"project\": {\"id\": \"3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1\"}}").RootElement,
            };

            mockAdoClient.Setup(m => m.GetBuild(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(fakeBuild));

            ITypeConverter<AdoEvent, AdoDto> sut = new AdoEventToAdoDtoConverter(mockAdoClient.Object);

            //Act            
            var result = sut.Convert(fakeBuildEvent, null, null) as BuildDto;

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result.Id, fakeBuildEvent.Resource?.GetProperty("id").GetInt32());
            Assert.Equal(result.Project.Id, fakeBuildEvent.ResourceContainers?.GetProperty("project").GetProperty("id").GetGuid());

            Mock.VerifyAll(mockAdoClient);
        }

        [Fact]
        public void CanConvertReleaseCreatedEventToReleaseDto()
        {
            //Arrange
            var mockAdoClient = new Mock<IAdoClient>();
            var fakeRelease = new ReleaseDto() { Id = 1, Project = new ProjectDto() { Id = new System.Guid("3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1") } };
            var fakeReleaseEvent = new ReleaseCompletedEvent()
            {
                EventType = ReleaseCompletedEvent.EventIdentifier,
                Resource = JsonDocument.Parse("{\"release\": {\"id\": 1}, \"project\": {\"id\": \"3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1\"}}").RootElement
            };

            mockAdoClient.Setup(m => m.GetRelease(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(fakeRelease));

            ITypeConverter<AdoEvent, AdoDto> sut = new AdoEventToAdoDtoConverter(mockAdoClient.Object);

            //Act
            var result = sut.Convert(fakeReleaseEvent, null, null) as ReleaseDto;

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result.Id, fakeReleaseEvent.Resource?.GetProperty("release").GetProperty("id").GetInt32());
            Assert.Equal(result.Project.Id, fakeReleaseEvent.Resource?.GetProperty("project").GetProperty("id").GetGuid());

            Mock.VerifyAll(mockAdoClient);
        }
    }
}
