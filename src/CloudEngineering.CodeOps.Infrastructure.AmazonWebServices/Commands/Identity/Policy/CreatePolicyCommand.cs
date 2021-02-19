using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy
{
    public sealed class CreatePolicyCommand : AwsCommand<Task>
    {
        public string PolicyName { get; init; }

        public string PolicyDocument { get; init; }

        public CreatePolicyCommand(string policyName, string policyDocument)
        {
            PolicyName = policyName;
            PolicyDocument = policyDocument;
        }
    }
}