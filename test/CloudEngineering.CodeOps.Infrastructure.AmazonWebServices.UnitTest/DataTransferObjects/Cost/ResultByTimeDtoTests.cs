using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.UnitTest.DataTransferObjects.Cost
{
    public class ResultByTimeDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ResultByTimeDto sut;

            //Act
            sut = new ResultByTimeDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ResultByTimeDto()
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1),
                Estimated = true,
                Total = new Dictionary<string, MetricValueDto>(),
                Groups = new List<GroupDto>()
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
            GroupDto sut;

            //Act
            sut = JsonSerializer.Deserialize<GroupDto>("{\"groups\":[],\"total\":[],\"startDate\":\"2021-03-05T10:41:41.2079256Z\",\"endDate\":\"2021-03-06T10:41:41.2400675Z\",\"estimated\": true}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}