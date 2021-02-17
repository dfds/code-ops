using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Shared
{
    public sealed class ChangeDto : AdoDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}