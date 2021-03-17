using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Release;
using System;
using System.Text.Json;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Events.Release
{
    public class ReleaseCompletedEventTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ReleaseCompletedEvent sut;

            //Act
            sut = new ReleaseCompletedEvent();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("ms.vss-release.deployment-completed-event", ReleaseCompletedEvent.EventIdentifier);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ReleaseCompletedEvent()
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
            ReleaseCompletedEvent sut;

            //Act
            sut = JsonSerializer.Deserialize<ReleaseCompletedEvent>("{\"id\":\"3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1\",\"publisherId\":\"MyPublisherId\",\"eventType\":\"MyEventType\",\"scope\":\"MyScope\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1", sut.Id);
            Assert.Equal("MyPublisherId", sut.PublisherId);
            Assert.Equal("MyEventType", sut.EventType);
            Assert.Equal("MyScope", sut.Scope);
        }
    }
}