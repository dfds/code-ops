﻿using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared
{
    public sealed class WorkItemDto : AdoDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}