using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost
{
    public class DimensionValueAttributeDto
    {
        [JsonPropertyName("attributes")]
        public IEnumerable<KeyValuePair<string, string>> Attributes { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}