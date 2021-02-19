using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy
{
    public sealed class CreatePolicyCommand : AwsCommand<Task>
    {
        [JsonPropertyName("policyName")]
        public string PolicyName { get; init; }

        [JsonPropertyName("policyDocument")]
        public string PolicyDocument { get; init; }

        public CreatePolicyCommand(string policyName, string policyDocument)
        {
            PolicyName = policyName;
            PolicyDocument = policyDocument;
        }
    }
}