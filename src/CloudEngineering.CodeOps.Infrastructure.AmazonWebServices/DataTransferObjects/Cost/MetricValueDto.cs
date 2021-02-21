using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost
{
    public class MetricValueDto
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}