using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class CreateRoleCommand : AwsCommand<Task>
    {
        [JsonPropertyName("roleName")]
        public string RoleName { get; init; }

        [JsonPropertyName("policyDocument")]
        public string PolicyDocument { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }

        [JsonPropertyName("tags")]
        public IEnumerable<KeyValuePair<string, string>> Tags { get; }

        public CreateRoleCommand(string roleName, string policyDocument, string description = "", IEnumerable<KeyValuePair<string, string>> tags = default)
        {
            RoleName = roleName;
            PolicyDocument = policyDocument;
            Tags = tags;
            Description = description;
        }
    }
}