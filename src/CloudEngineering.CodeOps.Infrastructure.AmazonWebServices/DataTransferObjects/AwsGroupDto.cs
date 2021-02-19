using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects
{
    public class AwsGroupDto
    {
        [JsonPropertyName("keys")] 
        public IEnumerable<string> Keys { get; set; }

        [JsonPropertyName("metrics")]
        public IEnumerable<KeyValuePair<string, AwsMetricValueDto>> Metrics { get; set; }
    }
}