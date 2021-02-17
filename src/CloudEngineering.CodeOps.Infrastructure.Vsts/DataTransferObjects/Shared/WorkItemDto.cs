using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Shared
{
    public sealed class WorkItemDto : VstsDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}