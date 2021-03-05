using Amazon.CostExplorer.Model;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Mapping.Converters
{
    public class GetCostAndUsageResponseToCostDtoConverterTests
    {
        [Fact]
        public void CanConvert()
        {
            //Arrange
            var sut = new GetCostAndUsageResponseToCostDtoConverter();
            var response = new GetCostAndUsageResponse()
            {
                DimensionValueAttributes = new System.Collections.Generic.List<DimensionValuesWithAttributes>(),
                ResultsByTime = new System.Collections.Generic.List<ResultByTime>()
            };

            //Act
            var result = sut.Convert(response, null, null);

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Empty(result.DimensionValueAttributes);
            Assert.Empty(result.ResultsByTime);
        }
    }
}
