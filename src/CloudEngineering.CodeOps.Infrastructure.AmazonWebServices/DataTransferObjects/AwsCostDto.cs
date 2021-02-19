using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects
{
    public class AwsCostDto
    {
        [JsonPropertyName("dimensionValueAttributes")]
        public IEnumerable<AwsDimensionValueAttributeDto> DimensionValueAttributes { get; set; }

        [JsonPropertyName("resultByTime")]
        public IEnumerable<AwsResultByTimeDto> ResultsByTime { get; set; }
    }
}