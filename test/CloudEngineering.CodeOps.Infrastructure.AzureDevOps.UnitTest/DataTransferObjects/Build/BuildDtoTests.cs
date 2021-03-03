using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Build;
using System.Text.Json;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.DataTransferObjects.Build
{
    public class BuildDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            BuildDto sut;

            //Act
            sut = new BuildDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new BuildDto()
            {
                Id = 1,
                BuildNumber = "1234"
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
            BuildDto sut;

            //Act
            sut = JsonSerializer.Deserialize<BuildDto>("{\"id\":1,\"buildNumber\":\"1234\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(1, sut.Id);
            Assert.Equal("1234", sut.BuildNumber);
        }
    }
}