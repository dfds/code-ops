using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed class UnregisterProfileCommand : AwsCommand<Task>
    {
        public IAwsProfile Profile { get; init; }

        internal string AccessKey { get; init; }

        internal string SecretKey { get; init; }

        public UnregisterProfileCommand(IAwsProfile profile, string accessKey = default, string secretKey = default)
        {
            Profile = profile;
            AccessKey = accessKey;
            SecretKey = secretKey;
        }
    }
}
