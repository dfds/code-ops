using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter
{
    public class ParameterDto
    {
        [JsonPropertyName("version")]
        public long Version { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
