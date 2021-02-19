using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects
{
    public class AwsMetricValueDto
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}