using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class CreateRoleCommand : AwsCommand<Task>
    {
        public string RoleName { get; init; }

        public string PolicyDocument { get; init; }

        public string Description { get; init; }

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