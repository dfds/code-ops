using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter
{
    public class ParameterDto
    {
        [JsonPropertyName("version")]
        public long Version { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("paramType")]
        public string ParamType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tags")]
        public KeyValuePair<string, string>[] Tags { get; set; }

        [JsonPropertyName("overwrite")]
        public bool Overwrite { get; set; }
    }
}
