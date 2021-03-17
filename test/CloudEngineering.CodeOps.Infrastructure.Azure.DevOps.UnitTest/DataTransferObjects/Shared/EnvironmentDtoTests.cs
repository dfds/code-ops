using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared;
using System.Text.Json;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.DataTransferObjects.Shared
{
    public class EnvironmentDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            EnvironmentDto sut;

            //Act
            sut = new EnvironmentDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new EnvironmentDto()
            {
                Name = "name",
                Status = "status"
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
            EnvironmentDto sut;

            //Act
            sut = JsonSerializer.Deserialize<EnvironmentDto>("{\"name\":\"name\",\"status\":\"status\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("name", sut.Name);
            Assert.Equal("status", sut.Status);
        }
    }
}