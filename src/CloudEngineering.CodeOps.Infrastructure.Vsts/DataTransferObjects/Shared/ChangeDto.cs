using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Shared
{
    public sealed class ChangeDto : VstsDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}