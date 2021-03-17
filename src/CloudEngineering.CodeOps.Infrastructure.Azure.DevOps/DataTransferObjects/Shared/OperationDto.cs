using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared
{
    public sealed class OperationDto : AdoDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("pluginId")]
        public string PluginId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}