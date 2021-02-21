using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Role
{
    public class RoleDto
    {
        [JsonPropertyName("arn")]
        public string Arn { get; set; }

        [JsonPropertyName("assumeRolePolicyDocument")]
        public string AssumeRolePolicyDocument { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("maxSessionDuration")]
        public int MaxSessionDuration { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("roleId")]
        public string RoleId { get; set; }

        [JsonPropertyName("roleName")]
        public string RoleName { get; set; }
    }
}
