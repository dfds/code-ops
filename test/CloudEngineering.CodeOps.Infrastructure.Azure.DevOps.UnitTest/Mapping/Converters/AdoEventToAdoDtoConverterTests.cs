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
        public void CanConvertAdoWebHookJsonToAdoEvent()
        {
            //Arrange
            var mockAdoClient = new Mock<IAdoClient>();
            var fakeBuild = new BuildDto() { Id = 1, Project = new ProjectDto() { Id = new System.Guid("3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1") } };
            var jsonStringData = "{\"subscriptionId\":\"fe2f7b26-0f07-4b5c-aef3-a6eac7831472\",\"notificationId\":1,\"id\":\"f3baab6b-9a65-4eb7-9dec-9c9ccdc49693\",\"eventType\":\"build.complete\",\"publisherId\":\"tfs\",\"message\":{\"text\":\"Build 20211123.4 succeeded\",\"html\":\"\",\"markdown\":\"Build [20211123.4](https://dfds.visualstudio.com/web/build.aspx?pcguid=564c8796-d9cf-412e-8ed3-a5a07bb574d2\u0026builduri=vstfs%3a%2f%2f%2fBuild%2fBuild%2f417043) succeeded\"},\"detailedMessage\":{\"text\":\"Build 20211123.4 succeeded\",\"html\":\"\",\"markdown\":\"Build [20211123.4](https://dfds.visualstudio.com/web/build.aspx?pcguid=564c8796-d9cf-412e-8ed3-a5a07bb574d2\u0026builduri=vstfs%3a%2f%2f%2fBuild%2fBuild%2f417043) succeeded\"},\"resource\":{\"uri\":\"vstfs:///Build/Build/417043\",\"id\":417043,\"buildNumber\":\"20211123.4\",\"url\":\"https://dfds.visualstudio.com/ace5e409-c242-4356-93f4-23c53a3dc87b/_apis/build/Builds/417043\",\"startTime\":\"2021-11-23T11:42:55.3482039Z\",\"finishTime\":\"2021-11-23T11:43:15.64782Z\",\"reason\":\"manual\",\"status\":\"succeeded\",\"drop\":{},\"log\":{},\"sourceGetVersion\":\"LG:refs/heads/main:fe7db3e48da92cc81e7ccd803c7b9a280156d527\",\"lastChangedBy\":{\"displayName\":\"Microsoft.VisualStudio.Services.TFS\",\"id\":\"00000000-0000-0000-0000-000000000000\",\"uniqueName\":\"00000002-0000-8888-8000-000000000000@2c895908-04e0-4952-89fd-54b0046d6288\"},\"retainIndefinitely\":false,\"definition\":{\"definitionType\":\"xaml\",\"id\":2425,\"name\":\"dfds.crossplane-configuration-dfds\",\"url\":\"https://dfds.visualstudio.com/ace5e409-c242-4356-93f4-23c53a3dc87b/_apis/build/Definitions/2425\"},\"requests\":[{\"id\":417043,\"url\":\"https://dfds.visualstudio.com/ace5e409-c242-4356-93f4-23c53a3dc87b/_apis/build/Requests/417043\",\"requestedFor\":{\"displayName\":\"Tobias Andersen\",\"id\":\"c41fd6b2-e2ff-6144-8e43-61a683fb2af1\",\"uniqueName\":\"toban@dfds.com\"}}]},\"resourceVersion\":\"1.0\",\"resourceContainers\":{\"collection\":{\"id\":\"564c8796-d9cf-412e-8ed3-a5a07bb574d2\",\"baseUrl\":\"https://dfds.visualstudio.com/\"},\"account\":{\"id\":\"d61c64a7-5a2c-4ee0-b50e-3972af43fa07\",\"baseUrl\":\"https://dfds.visualstudio.com/\"},\"project\":{\"id\":\"ace5e409-c242-4356-93f4-23c53a3dc87b\",\"baseUrl\":\"https://dfds.visualstudio.com/\"}},\"createdDate\":\"2021-11-23T11:43:27.7468922Z\"}";
            var adoWebHookJson = JsonDocument.Parse(jsonStringData);
            var adoEvent = new JsonElementToAdoEventConverter().Convert(adoWebHookJson.RootElement, null, null);

            mockAdoClient.Setup(m => m.GetBuild(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(fakeBuild));

            ITypeConverter<AdoEvent, AdoDto> sut = new AdoEventToAdoDtoConverter(mockAdoClient.Object);

            //Act
            var result = sut.Convert(adoEvent, null, null);
        }

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
