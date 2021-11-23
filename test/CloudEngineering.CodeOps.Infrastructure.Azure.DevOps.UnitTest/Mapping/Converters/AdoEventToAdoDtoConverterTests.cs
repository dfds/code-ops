using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Build;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Release;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters;
using Microsoft.Extensions.Options;
using Moq;
using System.Runtime.Serialization.Json;
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
            var jsonStringData = "{\"subscriptionId\":\"00000000-0000-0000-0000-000000000000\",\"notificationId\":286,\"id\":\"4a5d99d6-1c75-4e53-91b9-ee80057d4ce3\",\"eventType\":\"build.complete\",\"publisherId\":\"tfs\",\"message\":{\"text\":\"Build ConsumerAddressModule_20150407.2 succeeded\",\"html\":\"\",\"markdown\":\"\"},\"detailedMessage\":{\"text\":\"Build ConsumerAddressModule_20150407.2 succeeded\",\"html\":\"\",\"markdown\":\"\"},\"resource\":{\"uri\":\"vstfs:///Build/Build/2\",\"id\":416949,\"buildNumber\":\"ConsumerAddressModule_20150407.1\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/71777fbc-1cf2-4bd1-9540-128c1c71f766/_apis/build/Builds/2\",\"startTime\":\"2015-04-07T18:04:06.83Z\",\"finishTime\":\"2015-04-07T18:06:10.69Z\",\"reason\":\"manual\",\"status\":\"succeeded\",\"dropLocation\":\"#/3/drop\",\"drop\":{\"location\":\"#/3/drop\",\"type\":\"container\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_apis/resources/Containers/3/drop\",\"downloadUrl\":\"\"},\"log\":{\"type\":\"container\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_apis/resources/Containers/3/logs\",\"downloadUrl\":\"\"},\"sourceGetVersion\":\"LG:refs/heads/master:600c52d2d5b655caa111abfd863e5a9bd304bb0e\",\"lastChangedBy\":{\"displayName\":\"Normal Paulk\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db\",\"id\":\"d6245f20-2af8-44f4-9451-8107cb2767db\",\"uniqueName\":\"fabrikamfiber16@hotmail.com\",\"imageUrl\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db\"},\"retainIndefinitely\":false,\"hasDiagnostics\":true,\"definition\":{\"batchSize\":1,\"triggerType\":\"none\",\"definitionType\":\"xaml\",\"id\":2,\"name\":\"ConsumerAddressModule\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/71777fbc-1cf2-4bd1-9540-128c1c71f766/_apis/build/Definitions/2\"},\"queue\":{\"queueType\":\"buildController\",\"id\":4,\"name\":\"Hosted Build Controller\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_apis/build/Queues/4\"},\"requests\":[{\"id\":1,\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/71777fbc-1cf2-4bd1-9540-128c1c71f766/_apis/build/Requests/1\",\"requestedFor\":{\"displayName\":\"Normal Paulk\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db\",\"id\":\"d6245f20-2af8-44f4-9451-8107cb2767db\",\"uniqueName\":\"fabrikamfiber16@hotmail.com\",\"imageUrl\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db\"}}]},\"resourceVersion\":\"1.0\",\"resourceContainers\":{\"collection\":{\"id\":\"c12d0eb8-e382-443b-9f9c-c52cba5014c2\"},\"account\":{\"id\":\"f844ec47-a9db-4511-8281-8b63f4eaf94e\"},\"project\":{\"id\":\"ace5e409-c242-4356-93f4-23c53a3dc87b\"}},\"createdDate\":\"2021-11-15T12:17:14.6254691Z\"}";
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
