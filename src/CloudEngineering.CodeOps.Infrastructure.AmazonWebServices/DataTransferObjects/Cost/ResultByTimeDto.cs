using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost
{
    public class ResultByTimeDto
    {
        [JsonPropertyName("groups")]
        public IEnumerable<GroupDto> Groups { get; set; }

        [JsonPropertyName("total")]
        public IEnumerable<KeyValuePair<string, MetricValueDto>> Total { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("estimated")]
        public bool Estimated { get; set; }
    }
}