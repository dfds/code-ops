using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects
{
    public class AwsDimensionValueAttributeDto
    {
        [JsonPropertyName("attributes")]
        public IEnumerable<KeyValuePair<string, string>> Attributes { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}