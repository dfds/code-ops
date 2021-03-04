using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events.Release;
using System;
using System.Text.Json;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Events.Release
{
    public class ReleaseApprovalPendingEventTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ReleaseApprovalPendingEvent sut;

            //Act
            sut = new ReleaseApprovalPendingEvent();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("ms.vss-release.deployment-approval-pending-event", ReleaseApprovalPendingEvent.EventIdentifier);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ReleaseApprovalPendingEvent()
            {
                Id = Guid.NewGuid().ToString(),
                EventType = "MyEventType",
                PublisherId = "MyPublisherId",
                Scope = "MyScope"
            };

            //Act
            var payload = JsonSerializer.Serialize(sut, new JsonSerializerOptions { IgnoreNullValues = true });

            //Assert
            Assert.NotNull(JsonDocument.Parse(payload));
        }

        [Fact]
        public void CanBeDeserialized()
        {
            //Arrange
            ReleaseApprovalPendingEvent sut;

            //Act
            sut = JsonSerializer.Deserialize<ReleaseApprovalPendingEvent>("{\"id\":\"3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1\",\"publisherId\":\"MyPublisherId\",\"eventType\":\"MyEventType\",\"scope\":\"MyScope\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1", sut.Id);
            Assert.Equal("MyPublisherId", sut.PublisherId);
            Assert.Equal("MyEventType", sut.EventType);
            Assert.Equal("MyScope", sut.Scope);
        }
    }
}