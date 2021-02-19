using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects
{
    public class AwsResultByTimeDto
    {
        [JsonPropertyName("groups")]
        public IEnumerable<AwsGroupDto> Groups { get; set; }

        [JsonPropertyName("total")]
        public IEnumerable<KeyValuePair<string, AwsMetricValueDto>> Total { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("estimated")]
        public bool Estimated { get; set; }
    }
}