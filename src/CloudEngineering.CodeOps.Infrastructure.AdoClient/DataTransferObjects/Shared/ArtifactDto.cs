﻿using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Shared
{
    public sealed class ArtifactDto : AdoDto
    {
        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}