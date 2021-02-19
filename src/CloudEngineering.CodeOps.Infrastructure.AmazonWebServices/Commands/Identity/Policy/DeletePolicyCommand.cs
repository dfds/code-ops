using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity
{
    public sealed class DeletePolicyCommand : AwsCommand<Task>
    {
        public string PolicyArn { get; init; }

        public DeletePolicyCommand(string policyArn)
        {
            PolicyArn = policyArn;
        }
    }
}