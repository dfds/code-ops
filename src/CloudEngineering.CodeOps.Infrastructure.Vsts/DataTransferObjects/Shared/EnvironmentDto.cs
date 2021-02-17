using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Shared
{
    public sealed class EnvironmentDto : VstsDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}