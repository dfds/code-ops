using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy
{
    public class ManagedPolicyDto
    {
        [JsonPropertyName("arn")]
        public string Arn { get; set; }

        [JsonPropertyName("policyId")]
        public string PolicyId { get; set; }

        [JsonPropertyName("policyName")]
        public string PolicyName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}
