using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Project;
using CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Shared;

namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.DataTransferObjects.Release
{
    public sealed class ReleaseDto : AdoDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("artifacts")]
        public IEnumerable<ArtifactDto> Artifacts { get; set; }

        [JsonPropertyName("environments")]
        public IEnumerable<EnvironmentDto> Environments { get; set; }

        [JsonPropertyName("definition")]
        public ReleaseDefinitionDto Definition { get; set; }

        [JsonPropertyName("projectReference")]
        public ProjectDto Project { get; set; }
    }
}
