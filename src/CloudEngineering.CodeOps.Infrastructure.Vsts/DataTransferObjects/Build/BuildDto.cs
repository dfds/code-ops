using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Project;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Build
{
    public sealed class BuildDto : VstsDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("project")]
        public ProjectDto Project { get; set; }

        [JsonPropertyName("buildNumber")]
        public string BuildNumber { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("uri")]
        public Uri Uri { get; set; }

        [JsonPropertyName("definition")]
        public BuildDefinitionDto Definition { get; set; }

        [JsonPropertyName("tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}