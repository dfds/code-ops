using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Shared
{
    public sealed class ArtifactDto : VstsDto
    {
        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}