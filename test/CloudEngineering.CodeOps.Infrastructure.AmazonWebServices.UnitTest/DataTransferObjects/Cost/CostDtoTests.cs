using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.DataTransferObjects.Build
{
    public class CostDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            CostDto sut;

            //Act
            sut = new CostDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new CostDto()
            {
                DimensionValueAttributes = new List<DimensionValueAttributeDto>(),
                ResultsByTime = new List<ResultByTimeDto>()
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
            CostDto sut;

            //Act
            sut = JsonSerializer.Deserialize<CostDto>("{\"dimensionValueAttributes\":[],\"resultByTime\":[]}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}